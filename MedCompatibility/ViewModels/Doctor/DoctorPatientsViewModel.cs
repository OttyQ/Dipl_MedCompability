using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Doctor;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorPatientsViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly IUserSessionService _session;

    [ObservableProperty] private ObservableCollection<user> patients = new();
    [ObservableProperty] private bool isLoading;

    public DoctorPatientsViewModel(IUserService userService, IUserSessionService session)
    {
        _userService = userService;
        _session = session;
    }

    [RelayCommand]
    private async Task LoadDataAsync()
    {
        if (IsLoading) return;

        try
        {
            IsLoading = true;

            var doctor = _session.CurrentUser;
            if (doctor == null)
            {
                Patients.Clear();
                return;
            }

            // ВАЖНО: тут должен быть метод "мои пациенты" (по связке doctor-patient).
            var list = await _userService.GetDoctorPatientsAsync(doctor.UserId);
            Patients = new ObservableCollection<user>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task AddPatientAsync()
    {
        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        var popup = new PatientSearchPopup(_userService, _session);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is not user selectedPatient) return;

        await _userService.AddPatientToDoctorListAsync(doctor.UserId, selectedPatient.UserId);
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task OpenPatientAsync(user patient)
    {
        if (patient == null) return;

        var navParam = new Dictionary<string, object>
        {
            ["SelectedPatient"] = patient
        };

        await Shell.Current.GoToAsync(nameof(DoctorPatientCardPage), navParam);
    }

    [RelayCommand]
    private async Task GoBackAsync()
        => await Shell.Current.GoToAsync("..");

    [RelayCommand]
    private async Task LogoutAsync()
    {
        var confirm = await Shell.Current.DisplayAlert("Выход", "Выйти из аккаунта?", "Да", "Нет");
        if (!confirm) return;

        _session.EndSession();
        await Shell.Current.GoToAsync("Login");
    }
}
