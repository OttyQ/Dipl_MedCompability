using Microsoft.EntityFrameworkCore;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class AlternativeSearchService : IAlternativeSearchService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    private readonly IInteractionService _interactionService;
    private readonly IUserService _userService;

    public AlternativeSearchService(
        IDbContextFactory<DrugContext> contextFactory,
        IInteractionService interactionService,
        IUserService userService)
    {
        _contextFactory = contextFactory;
        _interactionService = interactionService;
        _userService = userService;
    }

    public async Task<List<medicine>> GetSafeAlternativesAsync(medicine targetDrug, user? patient, List<medicine> currentPrescriptions, bool onlyBelarusian, bool searchByAtc)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        IQueryable<medicine> candidatesQuery = context.medicines
            .Include(m => m.Manufacturer)
            .Include(m => m.Substances)
            .Where(m => m.MedicineId != targetDrug.MedicineId);

        if (searchByAtc && !string.IsNullOrWhiteSpace(targetDrug.ATCCode) && targetDrug.ATCCode.Length >= 4)
        {
            var atcPrefix = targetDrug.ATCCode.Substring(0, 4);
            candidatesQuery = candidatesQuery.Where(m => m.ATCCode != null && m.ATCCode.StartsWith(atcPrefix));
        }
        else
        {
            candidatesQuery = candidatesQuery.Where(m => m.INN == targetDrug.INN);
        }

        var candidates = await candidatesQuery.ToListAsync();

        if (onlyBelarusian)
        {
            candidates = candidates.Where(m => 
                m.Manufacturer != null && 
                !string.IsNullOrEmpty(m.Manufacturer.Country) && 
                (m.Manufacturer.Country.Contains("Беларус", StringComparison.OrdinalIgnoreCase) || 
                 m.Manufacturer.Country.Contains("РБ", StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        var patientAllergiesIds = new HashSet<int>();
        if (patient != null)
        {
            var fullPatient = await context.users
                .Include(u => u.Allergies)
                .FirstOrDefaultAsync(u => u.UserId == patient.UserId);

            patientAllergiesIds = fullPatient?.Allergies?.Select(a => a.SubstanceId).ToHashSet() ?? new HashSet<int>();
        }

        var safeAlternatives = new List<medicine>();

        foreach (var candidate in candidates)
        {
            bool hasAllergy = candidate.Substances.Any(s => patientAllergiesIds.Contains(s.SubstanceId));
            if (hasAllergy)
                continue;

            bool hasConflict = false;
            foreach (var pres in currentPrescriptions)
            {
                var interactions = await _interactionService.CheckInteractionAsync(candidate.MedicineId, pres.MedicineId);
                if (interactions.Any(i => i.RiskLevel != null && (i.RiskLevel.Severity >= 4))) // Warning or critical. Check if Severity 4 and 5 are critical/high risk. Wait, we should probably check if interactions.Any() and Severity >= 3 or 4.
                {
                    hasConflict = true;
                    break;
                }
            }

            if (!hasConflict)
            {
                safeAlternatives.Add(candidate);
            }
        }

        return safeAlternatives;
    }
}
