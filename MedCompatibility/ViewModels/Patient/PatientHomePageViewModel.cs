using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class PatientHomePageViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;

    [ObservableProperty]
    private string _welcomeText;

    [ObservableProperty]
    private bool _isGuest;

    [ObservableProperty]
    private bool _isUser;

    public PatientHomePageViewModel(IUserSessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task OnAppearingAsync()
    {
        IsGuest = _sessionService.IsGuest;
        IsUser = !_sessionService.IsGuest;
        WelcomeText = IsGuest ? "Гостевой режим" : _sessionService.CurrentUser?.FirstName ?? "Пациент";
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