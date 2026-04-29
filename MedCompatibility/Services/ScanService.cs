using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class ScanService : IScanService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    private readonly IUserSessionService _sessionService;
    private readonly IAppLogService _appLogService;

    public ScanService(IDbContextFactory<DrugContext> contextFactory, IUserSessionService sessionService, IAppLogService appLogService)
    {
        _contextFactory = contextFactory;
        _sessionService = sessionService;
        _appLogService = appLogService;
    }

    public async Task LogScanAsync(int medicineId)
    {
        // 1. Гостям историю не пишем (согласно ТЗ)
        if (!_sessionService.IsAuthenticated || _sessionService.CurrentUser == null)
            return;
        try
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            var newScan = new scan
            {
                UserId = _sessionService.CurrentUser.UserId,
                MedicineId = medicineId,
                ScannedAt = DateTime.Now
            };

            context.scans.Add(newScan);
            await context.SaveChangesAsync();

            // Аудит: записываем факт сканирования в системный лог
            var medicine = await context.medicines.FindAsync(medicineId);
            var tradeName = medicine?.TradeName ?? $"ID={medicineId}";
            await _appLogService.LogAsync("Info", "Scan", $"Пользователь отсканировал препарат: {tradeName}", _sessionService.CurrentUser.UserId);
        }
        catch (Exception ex)
        {
            // Логируем ошибку, но не роняем приложение, если история не записалась
            Console.WriteLine($"Ошибка записи истории: {ex.Message}");
        }
    }

    public async Task<List<scan>> GetUserHistoryAsync()
    {
        if (!_sessionService.IsAuthenticated || _sessionService.CurrentUser == null)
            return new List<scan>();

        using var context = await _contextFactory.CreateDbContextAsync();
        
        return await context.scans
            .Include(s => s.Medicine) // Подгружаем лекарство
            .Where(s => s.UserId == _sessionService.CurrentUser.UserId)
            .OrderByDescending(s => s.ScannedAt)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<List<scan>> GetAllScansAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        // Берем последние 100 записей, чтобы не грузить все миллионы
        return await context.scans
            .Include(s => s.Medicine)
            .Include(s => s.User) 
            .OrderByDescending(s => s.ScannedAt)
            .Take(100)
            .ToListAsync();
    }

}