using System.Threading.Tasks;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class DoctorStatsService : IDoctorStatsService
{
    private readonly IDbContextFactory<DrugContext> contextFactory;

    public DoctorStatsService(IDbContextFactory<DrugContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public async Task<DoctorStats> GetDoctorStatsAsync(int doctorId)
    {
        await using var ctx = await contextFactory.CreateDbContextAsync();

        var patients = await ctx.doctor_patient
            .AsNoTracking()
            .CountAsync(dp => dp.DoctorId == doctorId);

        var prescriptions = await ctx.prescriptions
            .AsNoTracking()
            .CountAsync(p => p.DoctorId == doctorId);

        return new DoctorStats(patients, prescriptions);
    }
}