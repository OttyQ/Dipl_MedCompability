using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IScanService
{
    // Записывает факт сканирования (если пользователь не гость)
    Task LogScanAsync(int medicineId);
    
    // Получает историю для текущего пользователя
    Task<List<scan>> GetUserHistoryAsync();
    Task<List<scan>> GetAllScansAsync();
}