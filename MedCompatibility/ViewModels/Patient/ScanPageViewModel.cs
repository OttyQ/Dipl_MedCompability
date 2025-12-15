using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared; // Тут твой CodeScannerPage
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ScanPageViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    private medicine foundMedicine;

    [ObservableProperty]
    private bool isMedicineVisible;

    [ObservableProperty]
    private bool isNotFoundVisible;

    [ObservableProperty]
    private string statusMessage;

    public ScanPageViewModel(IMedicineService medicineService, IScanService scanService)
    {
        _medicineService = medicineService;
        _scanService = scanService;
    }

    // Принимает результат от CodeScannerPage
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("ScannedCode"))
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                SearchQuery = code;
                await SearchAsync();
            }
        }
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery)) return;

        FoundMedicine = null;
        IsMedicineVisible = false;
        IsNotFoundVisible = false;
        StatusMessage = string.Empty;

        try
        {
            var medicine = await _medicineService.GetMedicineByGtinAsync(SearchQuery);
            // Если нужно по имени: if (medicine == null) medicine = await _medicineService.GetMedicineByNameAsync(SearchQuery);

            if (medicine != null)
            {
                FoundMedicine = medicine;
                IsMedicineVisible = true;
                await _scanService.LogScanAsync(medicine.MedicineId);
            }
            else
            {
                IsNotFoundVisible = true;
                StatusMessage = "Лекарство не найдено в базе данных.";
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Ошибка поиска: {ex.Message}";
            IsNotFoundVisible = true;
        }
    }

    [RelayCommand]
    private async Task ScanBarcodeAsync()
    {
        // Переходим на страницу камеры
        await Shell.Current.GoToAsync(nameof(CodeScannerPage));
    }
}
