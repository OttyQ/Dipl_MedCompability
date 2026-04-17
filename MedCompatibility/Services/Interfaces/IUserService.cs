using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IUserService
{
    Task<List<user>> GetAllUsersAsync();
    Task ToggleUserStatusAsync(int userId, bool isApproved);
    
    // Новые быстрые методы
    Task<int> GetPatientsCountAsync();
    Task<int> GetActiveDoctorsCountAsync();
    
    Task<List<user>> GetUsersFilteredAsync(string? searchText, string? roleName, string? status);
    // Удаление
    Task DeleteUserAsync(int userId);
    Task UpdateUserProfileAsync(int userId, string firstName, string lastName, string middleName);
    Task<List<user>> SearchPatientsAsync(string query);
    
    // Получить список пациентов, прикрепленных к врачу
    Task<List<user>> GetDoctorPatientsAsync(int doctorId);

// Добавить пациента к врачу
    Task AddPatientToDoctorListAsync(int doctorId, int patientId);

// Поиск пациентов, КОТОРЫХ ЕЩЕ НЕТ у этого врача (для добавления)
    Task<List<user>> SearchNewPatientsAsync(string query, int excludeDoctorId);

// Удалить (отвязать) пациента от врача
    Task RemovePatientFromDoctorListAsync(int doctorId, int patientId);
}