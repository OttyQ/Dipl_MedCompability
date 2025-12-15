using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IPrescriptionService
{
    Task<List<prescription>> GetPatientPrescriptionsAsync(int patientId);
    Task<prescription> AddPrescriptionAsync(int patientId, int doctorId, int medicineId, string? notes);
}