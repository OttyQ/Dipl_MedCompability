using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;
using System.Linq;
using Microsoft.Maui.Storage;

namespace MedCompatibility.ViewModels.Patient;

public partial class PatientHomePageViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly IPrescriptionService _prescriptionService;

    [ObservableProperty]
    private string _welcomeText;

    [ObservableProperty]
    private bool _isGuest;

    [ObservableProperty]
    private bool _isUser;

    [ObservableProperty]
    private bool _hasNewPrescriptions;

    public PatientHomePageViewModel(
        IUserSessionService sessionService,
        IPrescriptionService prescriptionService)
    {
        _sessionService = sessionService;
        _prescriptionService = prescriptionService;
    }

    public async Task OnAppearingAsync()
    {
        IsGuest = _sessionService.IsGuest;
        IsUser = !_sessionService.IsGuest;
        WelcomeText = IsGuest ? "Гостевой режим" : _sessionService.CurrentUser?.FirstName ?? "Пациент";

        await CheckNewPrescriptionsAsync();
    }

    private async Task CheckNewPrescriptionsAsync()
    {
        try
        {
            if (IsGuest) return;
            if (_sessionService.CurrentUser == null) return;

            var userId = _sessionService.CurrentUser.UserId;
            var prescriptions = await _prescriptionService.GetPatientPrescriptionsAsync(userId);

            if (prescriptions == null || !prescriptions.Any())
            {
                HasNewPrescriptions = false;
                return;
            }

            var withDate = prescriptions
                .Where(p => p.PrescribedAt.HasValue)
                .ToList();

            if (!withDate.Any())
            {
                HasNewPrescriptions = false;
                return;
            }

            var maxPrescribedAt = withDate.Max(p => p.PrescribedAt!.Value);
            var key = $"last_checked_prescriptions_{userId}";

            try
            {
                var stored = await SecureStorage.GetAsync(key);
                if (stored == null)
                {
                    HasNewPrescriptions = true;
                }
                else
                {
                    var lastChecked = DateTime.Parse(
                        stored, null,
                        System.Globalization.DateTimeStyles.RoundtripKind);
                    HasNewPrescriptions = maxPrescribedAt > lastChecked;
                }
            }
            catch
            {
                HasNewPrescriptions = true;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[CheckNewPrescriptions] Error: {ex.Message}");
            HasNewPrescriptions = false;
        }
    }

    [RelayCommand]
    public async Task GoToScanAsync() => await Shell.Current.GoToAsync(nameof(ScanPage));

    [RelayCommand]
    public async Task GoToCompatibilityAsync() => await Shell.Current.GoToAsync(nameof(CompatibilityPage));

    [RelayCommand]
    public async Task GoToHistoryAsync() => await Shell.Current.GoToAsync(nameof(HistoryPage));

    [RelayCommand]
    public async Task GoToProfileAsync() => await Shell.Current.GoToAsync(nameof(ProfilePage));

    [RelayCommand]
    private async Task GoToScheduleAsync()
    {
        await Shell.Current.GoToAsync(nameof(SchedulePage));
    }
    
    [RelayCommand]
    private async Task LogoutAsync()
    {
        var resultObj = await Shell.Current.ShowPopupAsync(
            new ConfirmPopup("Выход", "Вы уверены, что хотите выйти?", okText: "Да", cancelText: "Нет"));

        if (resultObj is bool ok && ok)
        {
            _sessionService.EndSession();
            await Shell.Current.GoToAsync("//Login");
        }
    }
}