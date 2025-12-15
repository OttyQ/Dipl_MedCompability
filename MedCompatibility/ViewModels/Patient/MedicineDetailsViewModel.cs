using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces; // Добавляем using

namespace MedCompatibility.ViewModels.Patient;

public partial class MedicineDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService; // Добавляем сервис

    [ObservableProperty]
    private medicine selectedMedicine;

    [ObservableProperty]
    private string substancesText;
    
    [ObservableProperty]
    private bool isLoading;

    // Внедряем сервис через конструктор
    public MedicineDetailsViewModel(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Medicine"))
        {
            var initialMed = query["Medicine"] as medicine;
            if (initialMed != null)
            {
                // Сначала показываем то, что есть (чтобы экран не был пустым)
                SelectedMedicine = initialMed;
                UpdateSubstancesText(); // Попытаемся отобразить вещества, если они есть

                // А теперь подгружаем ПОЛНЫЕ данные из базы (Manufacturer, Substances)
                await LoadFullDetailsAsync(initialMed.MedicineId);
            }
        }
    }

    private async Task LoadFullDetailsAsync(int medicineId)
    {
        try
        {
            IsLoading = true;
            // Используем метод получения по ID, который должен делать Include
            var fullMed = await _medicineService.GetMedicineByIdAsync(medicineId);
            
            if (fullMed != null)
            {
                SelectedMedicine = fullMed;
                UpdateSubstancesText();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading details: {ex.Message}");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void UpdateSubstancesText()
    {
        if (SelectedMedicine?.Substances != null && SelectedMedicine.Substances.Any())
        {
            SubstancesText = string.Join(", ", SelectedMedicine.Substances.Select(s => s.Name));
        }
        else
        {
            SubstancesText = "Нет данных";
        }
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
