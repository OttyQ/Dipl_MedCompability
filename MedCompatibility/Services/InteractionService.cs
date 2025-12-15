using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class InteractionService : IInteractionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public InteractionService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    // --- СУЩЕСТВУЮЩИЕ МЕТОДЫ (Оставляем как есть) ---

    public async Task<List<interaction>> GetAllInteractionsAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.interactions
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Include(i => i.InteractionType)
            .Include(i => i.RiskLevel)
            .OrderBy(i => i.SubstanceId1Navigation.Name)
            .AsNoTracking()
            .ToListAsync();
    }
    
    // ... (Методы Add, Delete, GetDictionaries оставляем без изменений) ...

    public async Task<List<interactiontype>> GetInteractionTypesAsync()
    {
         using var context = await _contextFactory.CreateDbContextAsync();
         return await context.interactiontypes.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<List<risklevel>> GetRiskLevelsAsync()
    {
         using var context = await _contextFactory.CreateDbContextAsync();
         return await context.risklevels.OrderBy(r => r.RiskLevelId).ToListAsync();
    }

    public async Task AddInteractionAsync(int subId1, int subId2, int typeId, int riskId, string desc, string recommendation)
    {
        // ... (Твой код добавления) ...
         if (subId1 == subId2)
            throw new Exception("Нельзя создать конфликт вещества с самим собой.");

        using var context = await _contextFactory.CreateDbContextAsync();

        var exists = await context.interactions.AnyAsync(i => 
            (i.SubstanceId1 == subId1 && i.SubstanceId2 == subId2) ||
            (i.SubstanceId1 == subId2 && i.SubstanceId2 == subId1));

        if (exists)
            throw new Exception("Такое взаимодействие уже существует.");

        var newInteraction = new interaction
        {
            SubstanceId1 = subId1,
            SubstanceId2 = subId2,
            InteractionTypeId = typeId,
            RiskLevelId = riskId,
            Description = desc,
            Recommendation = recommendation
        };

        context.interactions.Add(newInteraction);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteInteractionAsync(int id)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        var item = await context.interactions.FindAsync(id);
        if (item != null)
        {
            context.interactions.Remove(item);
            await context.SaveChangesAsync();
        }
    }

    public async Task<interaction?> GetInteractionByIdAsync(int id)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        return await context.interactions
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Include(i => i.InteractionType)
            .Include(i => i.RiskLevel)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.InteractionId == id);
    }

    public async Task UpdateInteractionAsync(interaction item)
    {
         using var context = await _contextFactory.CreateDbContextAsync();
        var exists = await context.interactions.AnyAsync(i => 
            i.InteractionId != item.InteractionId && 
            ((i.SubstanceId1 == item.SubstanceId1 && i.SubstanceId2 == item.SubstanceId2) ||
             (i.SubstanceId1 == item.SubstanceId2 && i.SubstanceId2 == item.SubstanceId1)));

        if (exists) throw new Exception("Такое взаимодействие уже существует.");

        context.interactions.Update(item);
        await context.SaveChangesAsync();
    }

    // --- НОВЫЙ МЕТОД: ПРОВЕРКА КОНФЛИКТА ---
    public async Task<List<interaction>> CheckInteractionAsync(int medicineId1, int medicineId2)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // 1. Получаем вещества первого лекарства
        var med1Substances = await context.medicines
            .Where(m => m.MedicineId == medicineId1)
            .SelectMany(m => m.Substances)
            .Select(s => s.SubstanceId)
            .ToListAsync();

        // 2. Получаем вещества второго лекарства
        var med2Substances = await context.medicines
            .Where(m => m.MedicineId == medicineId2)
            .SelectMany(m => m.Substances)
            .Select(s => s.SubstanceId)
            .ToListAsync();

        if (!med1Substances.Any() || !med2Substances.Any())
        {
            return new List<interaction>();
        }

        // 3. Ищем взаимодействия
        var conflicts = await context.interactions
            .Include(i => i.RiskLevel)
            .Include(i => i.InteractionType) // Чтобы показать тип (хотя ты просил скрыть, но в модели пусть будет)
            .Include(i => i.SubstanceId1Navigation)
            .Include(i => i.SubstanceId2Navigation)
            .Where(i => 
                (med1Substances.Contains(i.SubstanceId1) && med2Substances.Contains(i.SubstanceId2)) ||
                (med1Substances.Contains(i.SubstanceId2) && med2Substances.Contains(i.SubstanceId1))
            )
            .ToListAsync();

        return conflicts;
    }
}
