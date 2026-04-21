using System;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorHomeViewModel : ObservableObject
{
    private readonly IUserSessionService sessionService;
    private readonly ILoadingService loading;
    private readonly IDoctorStatsService statsService;

    [ObservableProperty] private string welcomeText = string.Empty;
    [ObservableProperty] private int patientsCount;
    [ObservableProperty] private int prescriptionsCount;

    public DoctorHomeViewModel(
        IUserSessionService sessionService,
        ILoadingService loading,
        IDoctorStatsService statsService)
    {
        this.sessionService = sessionService;
        this.loading = loading;
        this.statsService = statsService;

        UpdateWelcome();
    }

    public async Task OnAppearingAsync()
    {
        UpdateWelcome();

        var doctor = sessionService.CurrentUser;
        if (doctor == null)
        {
            PatientsCount = 0;
            PrescriptionsCount = 0;
            return;
        }

        try
        {
            loading.Show();

            var stats = await statsService.GetDoctorStatsAsync(doctor.UserId);
            PatientsCount = stats.Patients;
            PrescriptionsCount = stats.Prescriptions;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            loading.Hide();
        }
    }

    private void UpdateWelcome()
    {
        var user = sessionService.CurrentUser;
        if (user == null)
        {
            WelcomeText = string.Empty;
            return;
        }

        var name = $"{user.FirstName} {user.MiddleName}".Trim();
        WelcomeText = string.IsNullOrWhiteSpace(name) ? user.Login : name;
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        var resultObj = await Shell.Current.ShowPopupAsync(
            new ConfirmPopup("Выход", "Выйти из аккаунта?", okText: "Да", cancelText: "Нет"));

        if (resultObj is bool ok && ok)
        {
            sessionService.EndSession();
            await Shell.Current.GoToAsync("//Login");
        }
    }

    [RelayCommand] private Task GoToPatientsAsync() => Shell.Current.GoToAsync(nameof(DoctorPatientsPage));
    [RelayCommand] private Task GoToMedicinesAsync() => Shell.Current.GoToAsync(nameof(MedicinesListPage));
    [RelayCommand] private Task GoToInteractionsAsync() => Shell.Current.GoToAsync(nameof(InteractionsListPage));
    [RelayCommand] private Task GoToProfileAsync() => Shell.Current.GoToAsync(nameof(ProfilePage));
    
    [RelayCommand]
    private async Task GoToCrossAnalysisAsync()
    {
        await Shell.Current.GoToAsync(nameof(DoctorCrossAnalysisPage));
    }
}
