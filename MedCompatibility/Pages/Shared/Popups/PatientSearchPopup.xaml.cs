using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class PatientSearchPopup : Popup
{
    private readonly IUserService _userService;
    private readonly IUserSessionService _sessionService;

    public PatientSearchPopup(IUserService userService, IUserSessionService sessionService)
    {
        InitializeComponent();
        _userService = userService;
        _sessionService = sessionService;
    }

    private async void OnPopupOpened(object? sender, PopupOpenedEventArgs e)
    {
        await LoadPatientsAsync("");
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        await LoadPatientsAsync(e.NewTextValue ?? "");
    }

    private async Task LoadPatientsAsync(string query)
    {
        try
        {
            var doctor = _sessionService.CurrentUser;
            if (doctor == null) return;

            SetLoading(true);

            var patients = await _userService.SearchNewPatientsAsync(query, doctor.UserId);

            // ItemsSource лучше обновлять на UI-потоке. [web:29]
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                ResultsList.ItemsSource = patients;
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Ошибка поиска: {ex.Message}");
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void SetLoading(bool isLoading)
    {
        Loader.IsVisible = isLoading;
        Loader.IsRunning = isLoading;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is user selectedPatient)
            Close(selectedPatient);
    }

    private void OnCloseClicked(object sender, EventArgs e) => Close(null);
}