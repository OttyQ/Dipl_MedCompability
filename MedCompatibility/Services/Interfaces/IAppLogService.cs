using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IAppLogService
{
    Task LogAsync(string level, string action, string message, int? userId = null);
    Task<List<SystemLog>> GetRecentLogsAsync(int count = 50);
}
