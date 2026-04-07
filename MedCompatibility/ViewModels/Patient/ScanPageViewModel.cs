using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.ViewModels.Patient;

public partial class ScanPageViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;
    private readonly IUserSessionService _sessionService;

    private int _currentUserId = -1; // -1 означает, что страницу еще не открывали
    
    [ObservableProperty]
    private string _searchQuery;

    // Заменяем одно лекарство на список
    [ObservableProperty]
    private ObservableCollection<medicine> _foundMedicines = new();

    [ObservableProperty]
    private bool _isMedicineVisible;

    [ObservableProperty]
    private bool _isNotFoundVisible;

    [ObservableProperty]
    private bool _isBusy;
    
    [ObservableProperty]
    private bool _isClearButtonVisible;

    public ScanPageViewModel(IMedicineService medicineService, IScanService scanService, IUserSessionService sessionService)
    {
        _medicineService = medicineService;
        _scanService = scanService;
        _sessionService = sessionService;
    }
    
    // 2. Добавляем метод перехвата параметров
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // Проверяем, есть ли наш параметр от сканера
        if (query.TryGetValue("ScannedCode", out var codeObj) && codeObj is string code)
        {
            if (!string.IsNullOrWhiteSpace(code))
            {
                SearchQuery = code; // Подставляем код в строку
                SearchCommand.Execute(null); // Ищем
            }
            
            // 3. САМОЕ ВАЖНОЕ: Удаляем параметр из словаря!
            // Теперь Shell забудет про него, и при переключении вкладок код не вернется.
            query.Remove("ScannedCode");
        }
    }
    
    [RelayCommand]
    public async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
            return;

        IsBusy = true;
        IsNotFoundVisible = false;
        IsMedicineVisible = false;
        FoundMedicines.Clear();

        try
        {
            // Используем SearchMedicinesAsync, который ищет и по GTIN, и по названию
            var results = await _medicineService.SearchMedicinesAsync(SearchQuery);

            if (results != null && results.Any())
            {
                foreach (var med in results)
                {
                    FoundMedicines.Add(med);
                }
                
                IsMedicineVisible = true;

                // // Записываем в историю только если найдено ровно 1 совпадение (например, сканировали точный штрихкод)
                // if (results.Count == 1 && !_sessionService.IsGuest)
                // {
                //     await _scanService.LogScanAsync(results.First().MedicineId);
                // }
            }
            else
            {
                IsNotFoundVisible = true;
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Не удалось выполнить поиск.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    // Команда для перехода в детальную карточку
    [RelayCommand]
    public async Task GoToDetailsAsync(medicine selectedMed)
    {
        if (selectedMed == null) return;

        // Если хотим, чтобы в историю попадало при клике:
        if (!_sessionService.IsGuest)
        {
            await _scanService.LogScanAsync(selectedMed.MedicineId);
        }

        // Передаем объект лекарства на страницу MedicineDetailsPage
        var navParams = new Dictionary<string, object>
        {
            { "Medicine", selectedMed }
        };

        await Shell.Current.GoToAsync("MedicineDetailsPage", navParams);
    }
    
    [RelayCommand]
    public async Task ScanBarcodeAsync()
    {
        // Переход на страницу камеры сканера
        await Shell.Current.GoToAsync("CodeScannerPage");
    }
    
    public void CheckAndClearSessionState()
    {
        // Получаем ID текущего пользователя (или 0, если это гость)
        int sessionId = _sessionService.IsGuest ? 0 : _sessionService.CurrentUser?.UserId ?? 0;

        // Если страница уже открывалась, и ID пользователя изменился -> чистим данные
        if (_currentUserId != -1 && _currentUserId != sessionId)
        {
            SearchQuery = string.Empty;
            FoundMedicines.Clear();
            IsMedicineVisible = false;
            IsNotFoundVisible = false;
        }

        // Запоминаем текущего пользователя
        _currentUserId = sessionId;
    }
    
    // Этот специальный метод MAUI вызывает автоматически при любом изменении SearchQuery
    partial void OnSearchQueryChanged(string value)
    {
        IsClearButtonVisible = !string.IsNullOrEmpty(value);
    }
    
    // Команда очистки поиска
    [RelayCommand]
    public void ClearSearch()
    {
        SearchQuery = string.Empty;
        FoundMedicines.Clear();
        IsMedicineVisible = false;
        IsNotFoundVisible = false;
    }
}