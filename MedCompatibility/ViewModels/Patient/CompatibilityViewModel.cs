using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups; // Для nameof(CodeScannerPage)

namespace MedCompatibility.ViewModels.Patient;

public partial class CompatibilityViewModel : ObservableObject, IQueryAttributable
{
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    // Флаг, чтобы понимать, в какой слот (А или Б) мы сейчас выбираем лекарство
    private bool _isSelectingA; 

    [ObservableProperty]
    private medicine? medicineA;

    [ObservableProperty]
    private medicine? medicineB;

    [ObservableProperty]
    private ObservableCollection<interaction> foundConflicts = new();

    [ObservableProperty]
    private bool isBusy;
    
    [ObservableProperty]
    private bool hasConflicts;

    [ObservableProperty]
    private string statusMessage = "Выберите два лекарства для проверки";

    public CompatibilityViewModel(IInteractionService interactionService, IMedicineService medicineService, IScanService scanService)
    {
        _interactionService = interactionService;
        _medicineService = medicineService;
        _scanService = scanService;
    }

    // --- Обработка результата от сканера ---
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                // Ищем лекарство по коду
                await LoadMedicineByGtinAsync(code);
            }
        }
        query.Clear();
    }

    private async Task LoadMedicineByGtinAsync(string gtin)
    {
        try
        {
            var med = await _medicineService.GetMedicineByGtinAsync(gtin);
            if (med != null)
            {
                if (_isSelectingA) MedicineA = med;
                else MedicineB = med;
                
                StatusMessage = "Лекарство добавлено. Выберите второе или нажмите Проверить.";
            }
            else
            {
                await Shell.Current.DisplayAlert("Не найдено", $"Лекарство со штрихкодом {gtin} не найдено в базе", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }
    // ---------------------------------------

    [RelayCommand]
    private async Task SelectMedicineAAsync()
    {
        _isSelectingA = true; // Запоминаем, что выбираем для левого слота
        await OpenSelectionMenuAsync();
    }

    [RelayCommand]
    private async Task SelectMedicineBAsync()
    {
        _isSelectingA = false; // Запоминаем, что выбираем для правого слота
        await OpenSelectionMenuAsync();
    }

    private async Task OpenSelectionMenuAsync()
    {
        // Создаем попап, передавая сервисы
        var popup = new MedicineSelectionPopup(_medicineService, _scanService);
        
        // Показываем и ждем результат
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            // Пользователь выбрал сканер внутри попапа
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
        }
        else if (result is medicine selectedMed)
        {
            // Пользователь выбрал лекарство из списка
            if (_isSelectingA) MedicineA = selectedMed;
            else MedicineB = selectedMed;
            
            StatusMessage = "Лекарство добавлено. Выберите второе.";
            
            // Если оба выбраны - можно сразу проверить (опционально)
            // if (MedicineA != null && MedicineB != null) await CheckAsync();
        }
    }


    [RelayCommand]
    private async Task CheckAsync()
    {
        if (MedicineA == null || MedicineB == null)
        {
            await Shell.Current.DisplayAlert("Внимание", "Выберите оба лекарства для проверки", "OK");
            return;
        }

        if (IsBusy) return;
        IsBusy = true;
        FoundConflicts.Clear();
        HasConflicts = false;

        try
        {
            var results = await _interactionService.CheckInteractionAsync(MedicineA.MedicineId, MedicineB.MedicineId);
            
            if (results.Any())
            {
                FoundConflicts = new ObservableCollection<interaction>(results);
                HasConflicts = true;
                StatusMessage = $"⚠️ Найдено {results.Count} взаимодействий!";
            }
            else
            {
                StatusMessage = "✅ Взаимодействий не найдено. Комбинация безопасна.";
                HasConflicts = false;
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Ошибка проверки: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void Clear()
    {
        MedicineA = null;
        MedicineB = null;
        FoundConflicts.Clear();
        HasConflicts = false;
        StatusMessage = "Выберите два лекарства для проверки";
    }
}
