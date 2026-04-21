using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Pages.Shared; // Для доступа к CodeScannerPage

namespace MedCompatibility.ViewModels;

// --- Вспомогательные классы (без изменений) ---
public class CrossInteractionReport
{
    public medicine? Medicine1 { get; set; }
    public medicine? Medicine2 { get; set; }
    public interaction? Interaction { get; set; }
    public bool IsConflict { get; set; }
    public string SuccessMessage { get; set; } = string.Empty;

    public string Med1Substances => Medicine1?.Substances != null 
        ? string.Join(", ", Medicine1.Substances.Select(s => s.Name)) : string.Empty;
    public string Med2Substances => Medicine2?.Substances != null 
        ? string.Join(", ", Medicine2.Substances.Select(s => s.Name)) : string.Empty;
}

public partial class MedicineSlot : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasMedicine), nameof(IsPlaceholderVisible), nameof(DisplayName))]
    [NotifyPropertyChangedFor(nameof(InnMunText), nameof(SubstancesText))]
    private medicine? _selectedMedicine;

    public bool HasMedicine => SelectedMedicine != null;
    public bool IsPlaceholderVisible => SelectedMedicine == null;
    public string DisplayName => SelectedMedicine?.TradeName ?? "Нажмите, чтобы выбрать препарат...";

    public string InnMunText => SelectedMedicine != null 
        ? $"{SelectedMedicine.INN} | {SelectedMedicine.Manufacturer?.Name}" 
        : string.Empty;

    public string SubstancesText => SelectedMedicine?.Substances != null 
        ? string.Join(", ", SelectedMedicine.Substances.Select(s => s.Name)) 
        : string.Empty;
}

// --- ОСНОВНАЯ VIEWMODEL ---
public partial class DoctorCrossAnalysisViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMedicineService _medicineService;

    // Ссылка на слот, который мы сейчас наполняем (через поиск или сканер)
    private MedicineSlot? _activeSlot;

    [ObservableProperty] private ObservableCollection<MedicineSlot> _slots;
    [ObservableProperty] private ObservableCollection<CrossInteractionReport> _analysisReport; 
    [ObservableProperty] private bool _isAnalysisDone;

    public DoctorCrossAnalysisViewModel(IMedicineService medicineService)
    {
        _medicineService = medicineService;
        _slots = new ObservableCollection<MedicineSlot> { new(), new() };
        _analysisReport = new ObservableCollection<CrossInteractionReport>();
    }

    // 1. Обработка возврата со страницы сканера
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("ScannedCode") && _activeSlot != null)
        {
            string code = query["ScannedCode"]?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                await LoadMedicineByGtinAsync(code, _activeSlot);
            }
        }
        query.Clear();
    }

    private async Task LoadMedicineByGtinAsync(string gtin, MedicineSlot slot)
    {
        try
        {
            var med = await _medicineService.GetMedicineByGtinAsync(gtin);
            if (med != null)
            {
                var fullMed = await _medicineService.GetMedicineByIdAsync(med.MedicineId);
                slot.SelectedMedicine = fullMed ?? med;
                
                IsAnalysisDone = false;
                AnalysisReport.Clear();
            }
            else
            {
                await Shell.Current.DisplayAlert("Не найдено", $"Препарат с кодом {gtin} не найден", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task SelectMedicineForSlotAsync(MedicineSlot slot)
    {
        _activeSlot = slot;

        // ИСПРАВЛЕНО: showHistoryTab: false и передаем null вместо IScanService
        var popup = new UniversalSearchPopup(
            _medicineService, 
            null, 
            SearchMode.Лекарство, 
            showHistoryTab: false);

        var result = await Shell.Current.CurrentPage.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            // Переход на страницу сканера
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
        }
        else if (result is medicine med)
        {
            var fullMed = await _medicineService.GetMedicineByIdAsync(med.MedicineId);
            slot.SelectedMedicine = fullMed ?? med;
            IsAnalysisDone = false;
            AnalysisReport.Clear();
        }
    }

    [RelayCommand]
    private void AddSlot()
    {
        Slots.Add(new MedicineSlot());
        IsAnalysisDone = false;
        AnalysisReport.Clear();
    }

    [RelayCommand]
    private void RemoveSlot(MedicineSlot slot)
    {
        if (slot == null) return;
        if (Slots.Count > 2) Slots.Remove(slot);
        else slot.SelectedMedicine = null;

        IsAnalysisDone = false;
        AnalysisReport.Clear();
    }

    [RelayCommand]
    private async Task AnalyzeAsync()
    {
        var validSlots = Slots.Where(s => s.HasMedicine).ToList();
        if (validSlots.Count < 2)
        {
            await Application.Current!.MainPage!.DisplayAlert("Внимание", "Выберите минимум 2 препарата", "OK");
            return;
        }

        var ids = validSlots.Select(s => s.SelectedMedicine!.MedicineId).ToList();
        var rawResults = await _medicineService.AnalyzePolypharmacyAsync(ids);

        AnalysisReport.Clear();

        if (rawResults != null && rawResults.Any())
        {
            foreach (var res in rawResults)
            {
                AnalysisReport.Add(new CrossInteractionReport
                {
                    Medicine1 = res.Medicine1,
                    Medicine2 = res.Medicine2,
                    Interaction = res.InteractionDetails,
                    IsConflict = true
                });
            }
        }
        else
        {
            for (int i = 0; i < validSlots.Count; i++)
            {
                for (int j = i + 1; j < validSlots.Count; j++)
                {
                    AnalysisReport.Add(new CrossInteractionReport
                    {
                        Medicine1 = validSlots[i].SelectedMedicine,
                        Medicine2 = validSlots[j].SelectedMedicine,
                        IsConflict = false,
                        SuccessMessage = "Клинически значимых межлекарственных взаимодействий не обнаружено."
                    });
                }
            }
        }

        IsAnalysisDone = true;
    }
}