using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared; // CodeScannerPage
using MedCompatibility.Pages.Shared.Popups;

namespace MedCompatibility.ViewModels.Admin;

public partial class MedicineAddViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;
    private readonly ILoadingService _loading;

    [ObservableProperty]
    private medicine newMedicine = new();

    [ObservableProperty]
    private ObservableCollection<manufacturer> manufacturers = new();

    [ObservableProperty]
    private manufacturer selectedManufacturer;

    [ObservableProperty]
    private ObservableCollection<activesubstance> addedSubstances = new();

    [ObservableProperty]
    private string pageTitle = "Создание препарата";

    [ObservableProperty]
    private string buttonText = "Создать";

    public MedicineAddViewModel(IMedicineService medicineService, ILoadingService loading)
    {
        _medicineService = medicineService;
        _loading = loading;
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var list = await _medicineService.GetAllManufacturersAsync();
            Manufacturers = new ObservableCollection<manufacturer>(list);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading manufacturers: {ex}");
        }
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(NewMedicine.TradeName) ||
            string.IsNullOrWhiteSpace(NewMedicine.GTIN) ||
            string.IsNullOrWhiteSpace(NewMedicine.INN) ||
            SelectedManufacturer == null)
        {
            return;
        }

        try
        {
            _loading.Show();

            // Проверка дубликата GTIN (только при создании)
            if (NewMedicine.MedicineId == 0)
            {
                if (await _medicineService.ExistsMedicineByGtinAsync(NewMedicine.GTIN))
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Такой штрихкод уже есть в базе", "OK");
                    return;
                }
            }

            NewMedicine.ManufacturerId = SelectedManufacturer.ManufacturerId;
            if (NewMedicine.MedicineId == 0) NewMedicine.IsDeleted = false;

            var subIds = AddedSubstances.Select(s => s.SubstanceId).ToList();

            if (NewMedicine.MedicineId == 0)
            {
                await _medicineService.CreateMedicineAsync(NewMedicine, subIds);
                await Shell.Current.DisplayAlert("Успех", "Лекарство добавлено", "OK");
            }
            else
            {
                await _medicineService.UpdateMedicineAsync(NewMedicine, subIds);
                await Shell.Current.DisplayAlert("Успех", "Изменения сохранены", "OK");
            }

            await Shell.Current.GoToAsync("..");
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

    [RelayCommand]
    private async Task ScanBarcodeAsync()
    {
        await Shell.Current.GoToAsync(nameof(CodeScannerPage));
    }

    [RelayCommand]
    private async Task AddManufacturerAsync()
    {
        // Теперь не используется — вызов производится через OpenManufacturerPickerAsync
    }

    [RelayCommand]
    private async Task AddSubstanceAsync()
    {
        var popup = new UniversalSearchPopup(
            _medicineService,
            scanService: null,
            mode: SearchMode.Вещество,
            showAddSection: true,
            showHistoryTab: false);

        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is activesubstance subResult)
        {
            if (!AddedSubstances.Any(s => s.SubstanceId == subResult.SubstanceId))
                AddedSubstances.Add(subResult);
            else
                await Shell.Current.DisplayAlert("Инфо", "Это вещество уже добавлено", "OK");
        }
    }

    [RelayCommand]
    private void RemoveSubstance(activesubstance sub)
    {
        if (AddedSubstances.Contains(sub)) AddedSubstances.Remove(sub);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        // 1. Результат сканирования (ключ "ScannedCode")
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                NewMedicine.GTIN = code;
                OnPropertyChanged(nameof(NewMedicine)); // Чтобы UI обновился
            }
        }
        
        // Поддержка старого ключа на всякий случай, если где-то остался
        if (query.ContainsKey("ScanResult"))
        {
            string code = query["ScanResult"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                NewMedicine.GTIN = code;
                OnPropertyChanged(nameof(NewMedicine));
            }
        }

        // 2. Режим редактирования
        if (query.ContainsKey("MedicineToEdit"))
        {
            var source = query["MedicineToEdit"] as medicine;
            if (source != null)
            {
                InitializeEditModeAsync(source.MedicineId);
            }
        }
        
        query.Clear(); // Чистим параметры, чтобы при повторном открытии не сработало лишнего
    }

    private async Task InitializeEditModeAsync(int medicineId)
    {
        try
        {
            _loading.Show();

            if (Manufacturers.Count == 0)
            {
                var mans = await _medicineService.GetAllManufacturersAsync();
                Manufacturers = new ObservableCollection<manufacturer>(mans);
            }

            var fullMedicine = await _medicineService.GetMedicineByIdAsync(medicineId);
            if (fullMedicine == null) return;

            NewMedicine = new medicine
            {
                MedicineId = fullMedicine.MedicineId,
                TradeName = fullMedicine.TradeName,
                INN = fullMedicine.INN,
                Form = fullMedicine.Form,
                GTIN = fullMedicine.GTIN,
                Description = fullMedicine.Description,
                ManufacturerId = fullMedicine.ManufacturerId,
                IsDeleted = fullMedicine.IsDeleted
            };

            SelectedManufacturer = Manufacturers.FirstOrDefault(m => m.ManufacturerId == fullMedicine.ManufacturerId);

            AddedSubstances.Clear();
            if (fullMedicine.Substances != null)
            {
                foreach (var sub in fullMedicine.Substances) AddedSubstances.Add(sub);
            }

            PageTitle = "Редактирование";
            ButtonText = "Сохранить изменения";
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось загрузить данные: {ex.Message}", "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
    
    [RelayCommand]
    private async Task OpenManufacturerPickerAsync()
    {
        // Открываем UniversalSearchPopup в режиме «Производитель» с разрешением создания
        var popup = new UniversalSearchPopup(
            _medicineService,
            scanService: null,
            mode: SearchMode.Производитель,
            showAddSection: true,
            showHistoryTab: false);

        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is manufacturer m)
        {
            // Если производитель новый — добавь в кеш и выбери
            if (!Manufacturers.Any(x => x.ManufacturerId == m.ManufacturerId))
                Manufacturers.Add(m);
            SelectedManufacturer = Manufacturers.FirstOrDefault(x => x.ManufacturerId == m.ManufacturerId) ?? m;
        }
    }
}
