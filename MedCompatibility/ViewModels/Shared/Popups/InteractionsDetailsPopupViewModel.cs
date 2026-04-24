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
            var results = await _alternativeSearchService.GetSafeAlternativesAsync(
                TargetDrug,
                Patient,
                CurrentPrescriptions,
                SearchOnlyBelarusian,
                SearchByATC);

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
