using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class AppLogService : IAppLogService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public AppLogService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task LogAsync(string level, string action, string message, int? userId = null)
    {
        try
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            // Ленивая очистка: удаляем записи старше 7 дней
            var cutoff = DateTime.UtcNow.AddDays(-7);
            var oldLogs = await context.SystemLogs
                .Where(l => l.Timestamp < cutoff)
                .ToListAsync();

            if (oldLogs.Count > 0)
            {
                context.SystemLogs.RemoveRange(oldLogs);
            }

            // Добавляем новую запись
            context.SystemLogs.Add(new SystemLog
            {
                Timestamp = DateTime.UtcNow,
                Level = level,
                Action = action,
                Message = message,
                UserId = userId
            });

            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Логирование не должно ронять приложение
            Console.WriteLine($"AppLogService.LogAsync error: {ex.Message}");
        }
    }

    public async Task<List<SystemLog>> GetRecentLogsAsync(int count = 50)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        return await context.SystemLogs
            .Include(l => l.User)
            .OrderByDescending(l => l.Timestamp)
            .Take(count)
            .AsNoTracking()
            .ToListAsync();
    }
}
