namespace MedCompatibility.Services.Interfaces;

using System.Threading.Tasks;

public record DoctorStats(int Patients, int Prescriptions);

public interface IDoctorStatsService
{
    Task<DoctorStats> GetDoctorStatsAsync(int doctorId);
}