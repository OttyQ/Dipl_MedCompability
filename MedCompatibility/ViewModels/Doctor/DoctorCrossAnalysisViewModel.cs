using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Pages.Shared; // Для доступа к CodeScannerPage
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using System.IO;

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
    private readonly IPdfReportService _pdfReportService;
    private readonly IShare _share;
    private readonly IFileSaver _fileSaver;
    private readonly IUserSessionService _sessionService;
    private readonly IAlternativeSearchService _alternativeSearchService;
    private readonly IAiInteractionService _aiInteractionService;

    // Ссылка на слот, который мы сейчас наполняем (через поиск или сканер)
    private MedicineSlot? _activeSlot;

    [ObservableProperty] private ObservableCollection<MedicineSlot> _slots;
    [ObservableProperty] private ObservableCollection<CrossInteractionReport> _analysisReport; 
    [ObservableProperty] private bool _isAnalysisDone;

    // Свойства для Умного поиска
    [ObservableProperty] private bool _searchOnlyBelarusian = true;
    [ObservableProperty] private bool _searchByATC = false;
    [ObservableProperty] private ObservableCollection<medicine> _safeAlternatives = new();
    [ObservableProperty] private bool _isSearchLoading;
    [ObservableProperty] private bool _hasAlternatives;
    [ObservableProperty] private medicine? _targetAlternativeDrug;
    [ObservableProperty] private bool _isAlternativesPanelVisible;

    // Свойства для ИИ-анализа
    [ObservableProperty] private string _aiAnalysisResult = string.Empty;
    [ObservableProperty] private bool _isAiLoading;
    [ObservableProperty] private bool _aiAnalysisVisible;

    public DoctorCrossAnalysisViewModel(
        IMedicineService medicineService,
        IPdfReportService pdfReportService,
        IShare share,
        IFileSaver fileSaver,
        IUserSessionService sessionService,
        IAlternativeSearchService alternativeSearchService,
        IAiInteractionService aiInteractionService)
    {
        _medicineService = medicineService;
        _pdfReportService = pdfReportService;
        _share = share;
        _fileSaver = fileSaver;
        _sessionService = sessionService;
        _alternativeSearchService = alternativeSearchService;
        _aiInteractionService = aiInteractionService;
        _slots = new ObservableCollection<MedicineSlot> { new(), new() };
        _analysisReport = new ObservableCollection<CrossInteractionReport>();

        // Подписка на изменения коллекции слотов для автоочистки ИИ-результата
        _slots.CollectionChanged += (_, _) => ClearAiResult();
    }

    /// <summary>
    /// Сбрасывает результат ИИ-анализа (автоочистка при изменении списка препаратов).
    /// </summary>
    private void ClearAiResult()
    {
        AiAnalysisResult = string.Empty;
        AiAnalysisVisible = false;
        IsAiLoading = false;
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
                ClearAiResult();
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
            ClearAiResult();
        }
    }

    [RelayCommand]
    private void AddSlot()
    {
        Slots.Add(new MedicineSlot());
        IsAnalysisDone = false;
        AnalysisReport.Clear();
        ClearAiResult();
    }

    [RelayCommand]
    private void RemoveSlot(MedicineSlot slot)
    {
        if (slot == null) return;
        if (Slots.Count > 2) Slots.Remove(slot);
        else slot.SelectedMedicine = null;

        IsAnalysisDone = false;
        AnalysisReport.Clear();
        ClearAiResult();
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

    private async Task<byte[]> GeneratePdfBytesAsync()
    {
        var doctorName = _sessionService.CurrentUser?.FullName ?? "Врач";
        var validSlots = Slots.Where(s => s.HasMedicine).Select(s => s.SelectedMedicine!).ToList();
        
        var interactions = AnalysisReport
            .Where(r => r.IsConflict && r.Interaction != null)
            .Select(r => r.Interaction!)
            .ToList();

        return await _pdfReportService.GenerateCrossAnalysisReportAsync(doctorName, validSlots, interactions);
    }

    [RelayCommand]
    private async Task ShareReportAsync()
    {
        try
        {
            var pdfBytes = await GeneratePdfBytesAsync();
            var fileName = $"Анализ_препаратов_{DateTime.Now:ddMMyyyy}.pdf";
            var tempPath = Path.Combine(FileSystem.CacheDirectory, fileName);
            await File.WriteAllBytesAsync(tempPath, pdfBytes);

            await _share.RequestAsync(new ShareFileRequest
            {
                Title = "Отчет о совместимости препаратов",
                File = new ShareFile(tempPath)
            });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось поделиться отчетом: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task SaveReportAsync()
    {
        try
        {
            var pdfBytes = await GeneratePdfBytesAsync();
            var fileName = $"Анализ_препаратов_{DateTime.Now:ddMMyyyy}.pdf";
            
            using var stream = new MemoryStream(pdfBytes);
            var result = await _fileSaver.SaveAsync(fileName, stream, CancellationToken.None);
            
            if (result.IsSuccessful)
            {
                await Shell.Current.DisplayAlert("Успешно", $"Отчет сохранен по пути:\n{result.FilePath}", "OK");
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось сохранить отчет: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task FindAlternativeAsync(medicine drug)
    {
        if (drug == null) return;
        TargetAlternativeDrug = drug;
        IsAlternativesPanelVisible = true;
        IsSearchLoading = true;
        HasAlternatives = false;
        SafeAlternatives.Clear();

        try
        {
            var validSlots = Slots.Where(s => s.HasMedicine && s.SelectedMedicine!.MedicineId != drug.MedicineId)
                                  .Select(s => s.SelectedMedicine!).ToList();

            // Определяем конфликтующее вещество: ищем вещество из состава drug,
            // участвующее хотя бы в одном из найденных взаимодействий.
            int? conflictingSubstanceId = null;
            var drugSubIds = drug.Substances?.Select(s => s.SubstanceId).ToHashSet() ?? new HashSet<int>();
            var relevantConflicts = AnalysisReport
                .Where(r => r.IsConflict && r.Interaction != null &&
                            (r.Medicine1?.MedicineId == drug.MedicineId || r.Medicine2?.MedicineId == drug.MedicineId))
                .Select(r => r.Interaction!)
                .ToList();

            if (drugSubIds.Any() && relevantConflicts.Any())
            {
                var cid = relevantConflicts
                    .SelectMany(i => new[] { i.SubstanceId1, i.SubstanceId2 })
                    .FirstOrDefault(sid => drugSubIds.Contains(sid));
                if (cid != 0) conflictingSubstanceId = cid;
            }

            var alternatives = await _alternativeSearchService.GetSafeAlternativesAsync(
                TargetAlternativeDrug,
                null,
                validSlots,
                SearchOnlyBelarusian,
                SearchByATC,
                conflictingSubstanceId);

            foreach (var alt in alternatives)
            {
                SafeAlternatives.Add(alt);
            }
            HasAlternatives = SafeAlternatives.Any();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsSearchLoading = false;
        }
    }

    [RelayCommand]
    private async Task ReplaceDrugAsync(medicine replacement)
    {
        if (replacement == null || TargetAlternativeDrug == null) return;

        var slotToReplace = Slots.FirstOrDefault(s => s.SelectedMedicine?.MedicineId == TargetAlternativeDrug.MedicineId);
        if (slotToReplace != null)
        {
            var fullMed = await _medicineService.GetMedicineByIdAsync(replacement.MedicineId);
            slotToReplace.SelectedMedicine = fullMed ?? replacement;
            
            IsAlternativesPanelVisible = false;
            SafeAlternatives.Clear();
            TargetAlternativeDrug = null;

            await AnalyzeAsync();
        }
    }

    [RelayCommand] // ВАЖНО: Убрали CanExecute
    private async Task RunAiAnalysisAsync()
    {
        System.Diagnostics.Debug.WriteLine("=== AI Analysis Started ===");

        // --- One-time disclaimer ---
        bool disclaimerShown = Preferences.Default.Get("ai_disclaimer_shown", false);
        if (!disclaimerShown)
        {
            await Shell.Current.DisplayAlert(
                "ИИ анализ",
                "Результат формируется языковой моделью и может содержать неточности. Используйте как вспомогательный инструмент, решение принимает врач.",
                "Понятно");
            Preferences.Default.Set("ai_disclaimer_shown", true);
        }

        try
        {
            var medicines = Slots
                .Where(s => s.HasMedicine && s.SelectedMedicine != null)
                .Select(s => s.SelectedMedicine!)
                .ToList();

            System.Diagnostics.Debug.WriteLine($"Medicines count: {medicines.Count}");
            
            if (medicines.Count < 2)
            {
                AiAnalysisVisible = true;
                AiAnalysisResult = "⚠️ Для анализа ИИ необходимо минимум 2 добавленных препарата.";
                System.Diagnostics.Debug.WriteLine("AI Analysis aborted: Less than 2 medicines.");
                return;
            }

            IsAiLoading = true;
            AiAnalysisVisible = true; 
            AiAnalysisResult = "⏳ Анализирую данные...";

            System.Diagnostics.Debug.WriteLine("Calling AiInteractionService...");
            var result = await _aiInteractionService.AnalyzeInteractionsAsync(medicines);
            
            AiAnalysisResult = result;
            System.Diagnostics.Debug.WriteLine("AI Service returned response.");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"CRITICAL ERROR in ViewModel: {ex.Message}");
            AiAnalysisResult = $"⚠️ Ошибка: {ex.Message}";
        }
        finally
        {
            IsAiLoading = false;
            System.Diagnostics.Debug.WriteLine("=== AI Analysis Finished ===");
        }
    }

    private bool CanRunAiAnalysis() => !IsAiLoading && Slots.Count(s => s.HasMedicine) >= 2;
}