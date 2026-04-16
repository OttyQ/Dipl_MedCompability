using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared.Popups;

namespace MedCompatibility.ViewModels.Admin;

public partial class MedicinesListViewModel : ObservableObject
{
    private readonly IMedicineService _medicineService;
    private readonly ILoadingService _loading; // Твой сервис для Popup

    [ObservableProperty]
    private ObservableCollection<medicine> medicines = new();

    [ObservableProperty]
    private ObservableCollection<string> manufacturers = new();

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    private string selectedManufacturer = "Все";

    [ObservableProperty]
    private bool isBusy;

    public MedicinesListViewModel(IMedicineService medicineService, ILoadingService loading)
    {
        _medicineService = medicineService;
        _loading = loading;
    }

    // Инициализация (загрузка фильтров и данных)
    public async Task InitializeAsync()
    {
        if (Manufacturers.Count == 0)
        {
            await LoadManufacturersForFilterAsync();
        }
        await LoadDataAsync();
    }


    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (IsBusy) return;
        try
        {
            _loading.Show(); // Показываем Popup (если это не RefreshView)
            
            var list = await _medicineService.GetMedicinesFilteredAsync(SearchText, SelectedManufacturer);
            Medicines = new ObservableCollection<medicine>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
    
    // Команда для RefreshView
    [RelayCommand]
    public async Task RefreshDataAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            await LoadManufacturersForFilterAsync(); // Обновляем список

            var list = await _medicineService.GetMedicinesFilteredAsync(SearchText, SelectedManufacturer);
            Medicines = new ObservableCollection<medicine>(list);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ResetFiltersAsync()
    {
        SearchText = string.Empty;
        SelectedManufacturer = "Все";
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task DeleteMedicineAsync(medicine item)
    {
        if (item == null) return;
        
        bool confirm = await Shell.Current.DisplayAlert("Удаление", $"Удалить {item.TradeName}?", "Да", "Нет");
        if (confirm)
        {
            await _medicineService.DeleteMedicineAsync(item.MedicineId);
            await LoadDataAsync(); // Обновить список
        }
    }
    
    [RelayCommand]
    private async Task EditMedicineAsync(medicine item)
    {
        if (item == null) return;
        
        // Передаем весь объект на страницу добавления
        // Ключ "MedicineToEdit" будет сигналом, что мы в режиме редактирования
        var navParam = new Dictionary<string, object>
        {
            { "MedicineToEdit", item }
        };

        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicineAddPage), navParam);
    }
    
    // Вспомогательный метод для загрузки и конвертации
    private async Task LoadManufacturersForFilterAsync()
    {
        // 1. Запоминаем текущий выбор (до обновления коллекции)
        var currentSelection = SelectedManufacturer;

        var manObjects = await _medicineService.GetAllManufacturersAsync();
        var names = manObjects.Select(m => m.Name).ToList();
        names.Insert(0, "Все");

        // 2. Обновляем саму коллекцию
        Manufacturers = new ObservableCollection<string>(names);

        // 3. Жестко восстанавливаем выбор. Если старого значения в новом списке нет - ставим "Все"
        SelectedManufacturer = Manufacturers.Contains(currentSelection) ? currentSelection : "Все";
    }
    
    [RelayCommand]
    private async Task GoToAddMedicineAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicineAddPage));
    }

    // Реакция на изменение фильтра
    partial void OnSelectedManufacturerChanged(string value) => LoadDataCommand.Execute(null);

    // Выбор производителя через UniversalSearchPopup
    [RelayCommand]
    private async Task SelectManufacturerAsync()
    {
        var popup = new UniversalSearchPopup(
            _medicineService,
            scanService: null,
            mode: SearchMode.Производитель,
            showAddSection: false,
            showHistoryTab: false);

        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is manufacturer m)
        {
            SelectedManufacturer = m.Name;
        }
    }
}
