using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Services.Interfaces;
namespace MedCompatibility.ViewModels.Admin;
public partial class AdminHomeViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly ILoadingService _loading;

    [ObservableProperty] private int patientsCount = 0;
    [ObservableProperty] private int doctorsCount = 0;

    public AdminHomeViewModel(IUserService userService, ILoadingService loading)
    {
        _userService = userService;
        _loading = loading;
    }

    public async Task OnAppearingAsync()
    {
        try
        {
            _loading.Show();
            var patientsTask = _userService.GetPatientsCountAsync();
            var doctorsTask = _userService.GetActiveDoctorsCountAsync();
            await Task.WhenAll(patientsTask, doctorsTask);
            PatientsCount = patientsTask.Result;
            DoctorsCount = doctorsTask.Result;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert(
                "Ошибка",
                "Не удалось загрузить статистику: " + ex.Message,
                "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }
    [RelayCommand]
    private async Task LogoutAsync()
    {
        var resultObj = await Shell.Current.ShowPopupAsync(
            new Pages.Shared.Popups.ConfirmPopup(
                "Выход",
                "Выйти из аккаунта?",
                okText: "Выйти",
                cancelText: "Отмена"));

        if (resultObj is bool ok && ok)
            await Shell.Current.GoToAsync("//Login");
    }
    [RelayCommand]
    private async Task GoToUsersAsync()
    {
        await Shell.Current.GoToAsync("UsersList");
    }
    [RelayCommand]
    private async Task GoToMedicinesAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Admin.MedicinesListPage));
    }
    [RelayCommand]
    private async Task GoToConflictsAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionsListPage));
    }
    [RelayCommand]
    private async Task GoToSystemAsync()
    {
        await Shell.Current.GoToAsync(nameof(SystemLogsPage));
    }
}
