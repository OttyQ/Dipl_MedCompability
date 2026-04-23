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

    public InteractionsDetailsPopupViewModel(IPdfReportService pdfReportService, IShare share, IFileSaver fileSaver)
    {
        _pdfReportService = pdfReportService;
        _share = share;
        _fileSaver = fileSaver;
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
