using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IInteractionService
{
    // Получить список конфликтов (с include всех связей)
    Task<List<interaction>> GetAllInteractionsAsync();

    // Справочники для выпадающих списков
    Task<List<interactiontype>> GetInteractionTypesAsync();
    Task<List<risklevel>> GetRiskLevelsAsync();

    // Создать взаимодействие
    Task AddInteractionAsync(int subId1, int subId2, int typeId, int riskId, string desc, string recommendation);

    // Удалить
    Task DeleteInteractionAsync(int id);
    
    Task<interaction?> GetInteractionByIdAsync(int id);
    Task UpdateInteractionAsync(interaction item);
    Task<List<interaction>> CheckInteractionAsync(int medicineId1, int medicineId2);
}