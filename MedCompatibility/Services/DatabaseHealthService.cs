using System.Data.Common;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace MedCompatibility.Services;

public class DatabaseHealthService : IDatabaseHealthService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public bool IsAvailable { get; private set; }
    public string? LastErrorShort { get; private set; }
    public string? LastErrorDetails { get; private set; }

    public DatabaseHealthService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CheckAsync(CancellationToken ct = default)
    {
        LastErrorShort = null;
        LastErrorDetails = null;

        try
        {
            await using var ctx = await _contextFactory.CreateDbContextAsync(ct);

            // Быстрая проверка (может не дать деталей)
            if (await ctx.Database.CanConnectAsync(ct))
            {
                IsAvailable = true;
                return;
            }

            // Глубокая проверка: получаем реальную причину (exception message)
            try
            {
                DbConnection conn = ctx.Database.GetDbConnection();
                await conn.OpenAsync(ct);
                await conn.CloseAsync();
                IsAvailable = true;
            }
            catch (Exception ex)
            {
                IsAvailable = false;
                LastErrorShort = "Не удалось подключиться к базе данных.";
                LastErrorDetails = ex.ToString();
            }
        }
        catch (Exception ex)
        {
            IsAvailable = false;
            LastErrorShort = "База данных сейчас недоступна.";
            LastErrorDetails = ex.ToString();
        }
    }
}