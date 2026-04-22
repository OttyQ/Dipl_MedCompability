using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public PrescriptionService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

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

    public async Task<prescription?> GetByIdAsync(int prescriptionId)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.prescriptions
            .Include(p => p.Medicine)
            .Include(p => p.Doctor)
            .Include(p => p.Patient)
            .FirstOrDefaultAsync(p => p.PrescriptionId == prescriptionId);
    }

    public async Task<prescription> CreateAsync(
        int patientId,
        int doctorId,
        int medicineId,
        DateTime startDate,
        DateTime endDate,
        string dosage,
        string? notes)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var p = new prescription
        {
            PatientId = patientId,
            DoctorId = doctorId,
            MedicineId = medicineId,
            PrescribedAt = DateTime.Now,
            StartDate = startDate,
            EndDate = endDate,
            Dosage = dosage,
            Notes = notes
        };

        ctx.prescriptions.Add(p);
        await ctx.SaveChangesAsync();
        return p;
    }

    public async Task UpdateAsync(
        int prescriptionId,
        int doctorId,
        int medicineId,
        DateTime startDate,
        DateTime endDate,
        string dosage,
        string? notes)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var p = await ctx.prescriptions.FirstOrDefaultAsync(x => x.PrescriptionId == prescriptionId);
        if (p == null) throw new Exception("Назначение не найдено.");

        // Права: только автор
        if (p.DoctorId != doctorId)
            throw new UnauthorizedAccessException("Редактировать может только врач, который создал назначение.");

        p.MedicineId = medicineId;
        p.StartDate = startDate;
        p.EndDate = endDate;
        p.Dosage = dosage;
        p.Notes = notes;

        await ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(int prescriptionId, int doctorId)
    {
        await using var ctx = await _contextFactory.CreateDbContextAsync();

        var p = await ctx.prescriptions.FirstOrDefaultAsync(x => x.PrescriptionId == prescriptionId);
        if (p == null) return;

        // Права: только автор
        if (p.DoctorId != doctorId)
            throw new UnauthorizedAccessException("Удалять может только врач, который создал назначение.");

        ctx.prescriptions.Remove(p);
        await ctx.SaveChangesAsync();
    }
}
