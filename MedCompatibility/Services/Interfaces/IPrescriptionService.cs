using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IPrescriptionService
{
    Task<List<prescription>> GetPatientPrescriptionsAsync(int patientId);

    Task<prescription?> GetByIdAsync(int prescriptionId);

    // Создание (обязательные поля уже тут)
    Task<prescription> CreateAsync(
        int patientId,
        int doctorId,
        int medicineId,
        DateTime startDate,
        DateTime endDate,
        string dosage,
        string? notes);

    // Редактирование (разрешено только создателю)
    Task UpdateAsync(
        int prescriptionId,
        int doctorId,
        int medicineId,
        DateTime startDate,
        DateTime endDate,
        string dosage,
        string? notes);

    // Удаление (разрешено только создателю)
    Task DeleteAsync(int prescriptionId, int doctorId);
}