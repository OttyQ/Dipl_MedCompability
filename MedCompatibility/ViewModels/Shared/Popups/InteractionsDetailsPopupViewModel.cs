using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.IO;

namespace MedCompatibility.ViewModels;

public partial class InteractionsDetailsPopupViewModel : ObservableObject
{
    private readonly IPdfReportService _pdfReportService;
    private readonly IShare _share;
    private readonly IFileSaver _fileSaver;

    public List<interaction> Interactions { get; set; } = new();
    public user Patient { get; set; } = null!;
    public string DoctorName { get; set; } = string.Empty;
    public List<medicine> PastConflictingDrugs { get; set; } = new();
    public medicine TargetDrug { get; set; } = null!;
    public List<medicine> CurrentPrescriptions { get; set; } = new();

    /// <summary>Правка 3: метаданные остаточных взаимодействий (InteractionId → IsResidual, DaysAgoEnded)</summary>
    public Dictionary<int, (bool IsResidual, int DaysAgoEnded)> ResidualInfo { get; set; } = new();

    /// <summary>Получить IsResidual для конкретного InteractionId</summary>
    public bool IsResidualInteraction(int interactionId) =>
        ResidualInfo.TryGetValue(interactionId, out var v) && v.IsResidual;

    /// <summary>Получить DaysAgoEnded для конкретного InteractionId (0 если не остаточный)</summary>
    public int GetDaysAgoEnded(int interactionId) =>
        ResidualInfo.TryGetValue(interactionId, out var v) ? v.DaysAgoEnded : 0;

    [ObservableProperty] private bool _searchOnlyBelarusian = true;
    [ObservableProperty] private bool _searchByATC = false;
    [ObservableProperty] private ObservableCollection<medicine> _safeAlternatives = new();
    [ObservableProperty] private bool _isSearchLoading;
    [ObservableProperty] private bool _hasAlternatives;

    private readonly IAlternativeSearchService _alternativeSearchService;

    public InteractionsDetailsPopupViewModel(IPdfReportService pdfReportService, IShare share, IFileSaver fileSaver, IAlternativeSearchService alternativeSearchService)
    {
        _pdfReportService = pdfReportService;
        _share = share;
        _fileSaver = fileSaver;
        _alternativeSearchService = alternativeSearchService;
    }

    [RelayCommand]
    private async Task FindAlternativesAsync()
    {
        IsSearchLoading = true;
        try
        {
            // Определяем конфликтующее вещество из TargetDrug, чтобы исключить аналоги,
            // содержащие то же вещество (причину конфликта).
            int? conflictingSubstanceId = null;
            if (TargetDrug?.Substances != null && Interactions?.Count > 0)
            {
                var targetSubIds = TargetDrug.Substances.Select(s => s.SubstanceId).ToHashSet();
                conflictingSubstanceId = Interactions
                    .SelectMany(i => new[] { i.SubstanceId1, i.SubstanceId2 })
                    .FirstOrDefault(sid => targetSubIds.Contains(sid));
                if (conflictingSubstanceId == 0) conflictingSubstanceId = null;
            }

            var results = await _alternativeSearchService.GetSafeAlternativesAsync(
                TargetDrug,
                Patient,
                CurrentPrescriptions,
                SearchOnlyBelarusian,
                SearchByATC,
                conflictingSubstanceId);

            SafeAlternatives.Clear();
            foreach (var r in results)
                SafeAlternatives.Add(r);

            HasAlternatives = SafeAlternatives.Any();
            if (!HasAlternatives)
            {
                await Application.Current!.MainPage!.DisplayAlert("Результат", "Безопасных аналогов не найдено по заданным критериям.", "OK");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
        finally
        {
            IsSearchLoading = false;
        }
    }

    private async Task<byte[]> GeneratePdfBytesAsync()
    {
        return await _pdfReportService.GeneratePatientInteractionReportAsync(DoctorName, Patient, Interactions, PastConflictingDrugs);
    }

    [RelayCommand]
    private async Task ShareReportAsync()
    {
        try
        {
            var pdfBytes = await GeneratePdfBytesAsync();
            var fileName = $"Отчет_о_совместимости_{DateTime.Now:ddMMyyyy}.pdf";
            var tempPath = Path.Combine(FileSystem.CacheDirectory, fileName);
            await File.WriteAllBytesAsync(tempPath, pdfBytes);

            await _share.RequestAsync(new ShareFileRequest
            {
                Title = "Отчет о совместимости для пациента",
                File = new ShareFile(tempPath)
            });
        }
        catch (Exception ex)
        {
            // Ignore UI errors in popup VM or show alert
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }

    [RelayCommand]
    private async Task SaveReportAsync()
    {
        try
        {
            var pdfBytes = await GeneratePdfBytesAsync();
            var fileName = $"Отчет_о_совместимости_{DateTime.Now:ddMMyyyy}.pdf";
            
            using var stream = new MemoryStream(pdfBytes);
            var result = await _fileSaver.SaveAsync(fileName, stream, CancellationToken.None);
            
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
        }
    }
}
