using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IMedicineService
{
    // Получить список с фильтрацией (поиск + производитель)
    Task<List<medicine>> GetMedicinesFilteredAsync(string searchText, string manufacturerName);
    
    // Получить всех производителей (для фильтра в UI)
    Task<List<manufacturer>> GetAllManufacturersAsync();

    // Удалить (мягкое удаление)
    Task DeleteMedicineAsync(int id);
    
    // Добавляем методы создания справочников
    Task<manufacturer> CreateManufacturerAsync(string name, string country, string city, string description);
    Task<activesubstance> CreateSubstanceAsync(string name, string description);
    Task<List<activesubstance>> SearchSubstancesAsync(string query); // Для поиска при добавлении
    Task CreateMedicineAsync(medicine med, List<int> substanceIds); // Сохранение лекарства со связями
    Task<bool> ExistsMedicineByGtinAsync(string gtin); // Проверка на дубли
    Task<medicine?> GetMedicineByGtinAsync(string gtin);
    
    Task UpdateMedicineAsync(medicine med, List<int> substanceIds);
    Task<medicine?> GetMedicineByIdAsync(int id);
    Task<List<medicine>> SearchMedicinesAsync(string query);

}