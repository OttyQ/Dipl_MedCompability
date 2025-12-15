using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public PrescriptionService(IDbContextFactory<DrugContext> contextFactory)
        => _contextFactory = contextFactory;

    public async Task<List<prescription>> GetPatientPrescriptionsAsync(int patientId)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        return await ctx.prescriptions
            .AsNoTracking()
            .Where(p => p.PatientId == patientId)
            .Include(p => p.Medicine)
            .Include(p => p.Doctor)
            .OrderByDescending(p => p.PrescribedAt)
            .ToListAsync();
    }

    public async Task<prescription> AddPrescriptionAsync(int patientId, int doctorId, int medicineId, string? notes)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var p = new prescription
        {
            PatientId = patientId,
            DoctorId = doctorId,
            MedicineId = medicineId,
            Notes = notes,
            PrescribedAt = DateTime.Now
        };

        ctx.prescriptions.Add(p);
        await ctx.SaveChangesAsync();
        return p;
    }
}