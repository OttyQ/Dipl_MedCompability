using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class MedicineService : IMedicineService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public MedicineService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<medicine>> GetMedicinesFilteredAsync(string searchText, string manufacturerName)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        // Include обязательно нужен, чтобы показать имя производителя и состав
        var query = context.medicines
                           .Include(m => m.Manufacturer) 
                           .Include(m => m.Substances)
                           .AsNoTracking()
                           .AsQueryable();

        // 1. Поиск (Название, INN, Штрихкод или Активные вещества)
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            string lowerSearch = searchText.ToLower();
            query = query.Where(m => 
                m.TradeName.ToLower().Contains(lowerSearch) ||
                m.GTIN.Contains(lowerSearch) || 
                (m.INN != null && m.INN.ToLower().Contains(lowerSearch)) ||
                m.Substances.Any(s => s.Name.ToLower().Contains(lowerSearch)));
        }

        // 2. Фильтр по производителю
        if (!string.IsNullOrWhiteSpace(manufacturerName) && manufacturerName != "Все")
        {
            query = query.Where(m => m.Manufacturer.Name == manufacturerName);
        }

        return await query.OrderBy(m => m.TradeName).ToListAsync();
    }

    public async Task<List<manufacturer>> GetAllManufacturersAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.manufacturers
            .OrderBy(m => m.Name)
            .ToListAsync();
    }

    public async Task DeleteMedicineAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var item = await context.medicines.FindAsync(id);
        if (item != null)
        {
            item.IsDeleted = true;
            item.GTIN = $"DEL_{item.GTIN}_{DateTime.Now.Ticks}".Substring(0, Math.Min(49, $"DEL_{item.GTIN}_{DateTime.Now.Ticks}".Length)); 
        
            await context.SaveChangesAsync();
        }
    }

    public async Task<manufacturer> CreateManufacturerAsync(string name, string country, string city, string description)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        var existing = await context.manufacturers.FirstOrDefaultAsync(m => m.Name == name);
        if (existing != null) return existing;

        var newItem = new manufacturer
        {
            Name = name,
            Country = string.IsNullOrWhiteSpace(country) ? "Республика Беларусь" : country,
            City = city,
            Description = description // <--- Сохраняем
        };
    
        context.manufacturers.Add(newItem);
        await context.SaveChangesAsync();
    
        return newItem;
    }



    public async Task<activesubstance> CreateSubstanceAsync(string name, string description)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var newItem = new activesubstance { Name = name, Description = description };
        context.activesubstances.Add(newItem);
        await context.SaveChangesAsync();
        return newItem;
    }

    public async Task<List<activesubstance>> SearchSubstancesAsync(string query)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        if (string.IsNullOrWhiteSpace(query))
        {
            // Если запрос пустой - возвращаем ВСЕ (или первые 50)
            return await context.activesubstances
                .OrderBy(s => s.Name)
                .Take(50) // Лимит для безопасности
                .ToListAsync();
        }

        return await context.activesubstances
            .Where(s => s.Name.Contains(query))
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public async Task CreateMedicineAsync(medicine med, List<int> substanceIds)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        // 1. Добавляем само лекарство
        context.medicines.Add(med);
        await context.SaveChangesAsync(); // Чтобы получить med.MedicineId

        // 2. Привязываем вещества (Таблица MedicineSubstance)
        if (substanceIds != null && substanceIds.Any())
        {
            // В EF Core Many-to-Many можно добавлять через коллекцию, 
            // но так как у нас связь через промежуточный объект (Dictionary или скрытый), 
            // проще выполнить SQL или приаттачить сущности.

            // Самый надежный способ в EF Core 6/7/8 для M:N без явной сущности связи:
            var substances = await context.activesubstances.Where(s => substanceIds.Contains(s.SubstanceId))
                .ToListAsync();

            // Важно: загружаем текущую коллекцию (она пустая, но инициализируется)
            // context.Entry(med).Collection(m => m.Substances).Load(); // Если бы мы были в одном контексте

            // Так как контекст новый, нам нужно прикрепить med (он уже Added) и добавить в коллекцию
            med.Substances = substances;
            await context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsMedicineByGtinAsync(string gtin)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.medicines.AnyAsync(m => m.GTIN == gtin && !m.IsDeleted);
    }
    
    public async Task<medicine?> GetMedicineByGtinAsync(string gtin)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
    
        return await context.medicines
            .Include(m => m.Manufacturer) // Подгружаем производителя
            .Include(m => m.Substances)   // Подгружаем вещества
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.GTIN == gtin && !m.IsDeleted);
    }
    
    public async Task UpdateMedicineAsync(medicine med, List<int> substanceIds)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        // 1. Ищем существующее лекарство с подгрузкой веществ
        var existingMed = await context.medicines
            .Include(m => m.Substances)
            .FirstOrDefaultAsync(m => m.MedicineId == med.MedicineId);

        if (existingMed == null) throw new Exception("Лекарство не найдено");

        // 2. Обновляем простые поля
        existingMed.TradeName = med.TradeName;
        existingMed.INN = med.INN;
        existingMed.Form = med.Form;
        existingMed.GTIN = med.GTIN;
        existingMed.ManufacturerId = med.ManufacturerId;
        existingMed.Description = med.Description;
        // Не трогаем IsDeleted, prescriptions, scans

        // 3. Обновляем связи Many-to-Many (Вещества)
        // Очищаем старые связи
        existingMed.Substances.Clear();

        // Добавляем новые, если есть
        if (substanceIds != null && substanceIds.Any())
        {
            var substances = await context.activesubstances
                .Where(s => substanceIds.Contains(s.SubstanceId))
                .ToListAsync();
             
            foreach (var sub in substances)
            {
                existingMed.Substances.Add(sub);
            }
        }

        await context.SaveChangesAsync();
    }
    
    public async Task<medicine?> GetMedicineByIdAsync(int id)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.medicines
            .Include(m => m.Manufacturer)
            .Include(m => m.Substances)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.MedicineId == id);
    }
    
    public async Task<List<medicine>> SearchMedicinesAsync(string query)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        if (string.IsNullOrWhiteSpace(query))
        {
            return await context.medicines
                .Include(m => m.Manufacturer)
                .OrderBy(m => m.TradeName)
                .Take(50)
                .ToListAsync();
        }
    
        // Ищем по GTIN (полное совпадение) или по Названию (частичное)
        return await context.medicines
            .Include(m => m.Manufacturer) // Подгружаем производителя для красоты
            .Where(m => m.GTIN.Contains(query) || 
                        m.TradeName.Contains(query) || 
                        m.INN.Contains(query))
            .Take(20) // Ограничиваем список, чтобы не грузить базу
            .ToListAsync();
    }
    
    public async Task<List<CrossAnalysisResult>> AnalyzePolypharmacyAsync(List<int> medicineIds)
    {
        var results = new List<CrossAnalysisResult>();

        if (medicineIds == null || medicineIds.Count < 2)
            return results;

        // Создаем контекст через фабрику, как и в остальных твоих методах
        using var context = await _contextFactory.CreateDbContextAsync();

        // 1. Загружаем все выбранные препараты вместе с их веществами
        var medicines = await context.medicines
            .Include(m => m.Substances)
            .Where(m => medicineIds.Contains(m.MedicineId))
            .ToListAsync();

        // 2. Извлекаем все уникальные ID веществ из этих препаратов
        var allSubstanceIds = medicines
            .SelectMany(m => m.Substances.Select(s => s.SubstanceId))
            .Distinct()
            .ToList();

        // 3. Загружаем потенциальные взаимодействия только для этих веществ
        // ПРИМЕЧАНИЕ: проверь точное имя DbSet для взаимодействий в твоем DrugContext. 
        // Я предполагаю, что он называется interactions (по аналогии с medicines)
        var interactions = await context.interactions
            .Include(i => i.InteractionType)
            .Include(i => i.RiskLevel)
            .Where(i => allSubstanceIds.Contains(i.SubstanceId1) && allSubstanceIds.Contains(i.SubstanceId2))
            .ToListAsync();

        // 4. Попарно сравниваем препараты
        for (int i = 0; i < medicines.Count; i++)
        {
            for (int j = i + 1; j < medicines.Count; j++)
            {
                var med1 = medicines[i];
                var med2 = medicines[j];

                var med1Substances = med1.Substances.Select(s => s.SubstanceId).ToList();
                var med2Substances = med2.Substances.Select(s => s.SubstanceId).ToList();

                // Ищем пересечения веществ между med1 и med2
                var crossInteractions = interactions.Where(inter =>
                    (med1Substances.Contains(inter.SubstanceId1) && med2Substances.Contains(inter.SubstanceId2)) ||
                    (med1Substances.Contains(inter.SubstanceId2) && med2Substances.Contains(inter.SubstanceId1))
                ).ToList();

                foreach (var interaction in crossInteractions)
                {
                    results.Add(new CrossAnalysisResult
                    {
                        Medicine1 = med1,
                        Medicine2 = med2,
                        InteractionDetails = interaction
                    });
                }
            }
        }

        // 5. Исключаем дубликаты (имена свойств анонимного типа теперь заданы явно: Med1Id, Med2Id)
        return results
            .DistinctBy(r => new 
            { 
                Med1Id = r.Medicine1.MedicineId, 
                Med2Id = r.Medicine2.MedicineId, 
                InteractionId = r.InteractionDetails.InteractionId 
            })
            .ToList();
    }

}
