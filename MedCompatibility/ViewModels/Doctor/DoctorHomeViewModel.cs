using CommunityToolkit.Maui.Views; // Обязательно для ShowPopupAsync
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Patient;
using MedCompatibility.Pages.Shared.Popups; // Тут лежит наш ConfirmPopup
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorHomeViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly ILoadingService _loading;
    // В будущем сюда добавим IUserService или IDoctorService для загрузки реальной статистики

    [ObservableProperty]
    private string welcomeText;

    [ObservableProperty]
    private int patientsCount = 0;

    [ObservableProperty]
    private int prescriptionsCount = 0;

    public DoctorHomeViewModel(IUserSessionService sessionService, ILoadingService loading)
    {
        _sessionService = sessionService;
        _loading = loading;
        UpdateInfo();
    }

    // Метод, который вызывается при открытии страницы (из CodeBehind)
    public async Task OnAppearingAsync()
    {
        UpdateInfo();

        // Пример загрузки статистики (как в Админке). 
        // Пока оставим заглушки или простые значения, 
        // но структура готова для внедрения реальных запросов к БД.
        /*
        try 
        {
            _loading.Show();
            // var stats = await _doctorService.GetStatsAsync();
            // PatientsCount = stats.Patients;
            // PrescriptionsCount = stats.Prescriptions;
        } 
        finally 
        {
            _loading.Hide();
        }
        */
        await Task.CompletedTask; 
    }

    private void UpdateInfo()
    {
        var user = _sessionService.CurrentUser;
        WelcomeText = user != null
            ? $"{user.FirstName} {user.MiddleName}"
            : "Врач";
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        // --- ИСПОЛЬЗУЕМ КРАСИВЫЙ ПОПАП ---
        var resultObj = await Shell.Current.ShowPopupAsync(
            new ConfirmPopup(
                "Выход",
                "Вы уверены, что хотите выйти из аккаунта?",
                okText: "Выйти",
                cancelText: "Отмена"));

        if (resultObj is bool ok && ok)
        {
            _sessionService.EndSession();
            await Shell.Current.GoToAsync("//Login");
        }
    }

    [RelayCommand]
    private async Task GoToPatientsAsync()
    {
        await Shell.Current.GoToAsync(nameof(DoctorPatientsPage));
    }

    [RelayCommand]
    private async Task GoToMedicinesAsync()
    {
        await Shell.Current.GoToAsync(nameof(MedicinesListPage));
    }

    [RelayCommand]
    private async Task GoToInteractionsAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionsListPage));
    }

    [RelayCommand]
    private async Task GoToProfileAsync()
    {
        await Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}
