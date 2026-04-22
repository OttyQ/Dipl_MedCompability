using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Doctor;

namespace MedCompatibility.ViewModels.Doctor;

public partial class DoctorPatientCardViewModel : ObservableObject, IQueryAttributable
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;
    private readonly IUserSessionService _session;
    private readonly IUserService _userService;

    [ObservableProperty] private user? patient;
    [ObservableProperty] private ObservableCollection<prescription> prescriptions = new();
    [ObservableProperty] private bool isBusy;

    public string PatientFullName =>
        Patient == null ? "" : $"{Patient.LastName} {Patient.FirstName} {Patient.MiddleName}".Trim();

    public string PatientLogin => Patient == null ? "" : $"@{Patient.Login}";

    public DoctorPatientCardViewModel(
        IPrescriptionService prescriptionService,
        IInteractionService interactionService,
        IMedicineService medicineService,
        IScanService scanService,
        IUserSessionService session,
        IUserService userService)
    {
        _prescriptionService = prescriptionService;
        _interactionService = interactionService;
        _medicineService = medicineService;
        _scanService = scanService;
        _session = session;
        _userService = userService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("SelectedPatient", out var obj) && obj is user u)
        {
            Patient = u;
            OnPropertyChanged(nameof(PatientFullName));
            OnPropertyChanged(nameof(PatientLogin));

            // важно: грузим данные после установки Patient
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                if (LoadDataCommand.CanExecute(null))
                    await LoadDataCommand.ExecuteAsync(null);
            });
        }
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (Patient == null || IsBusy) return;

        try
        {
            IsBusy = true;
            var list = await _prescriptionService.GetPatientPrescriptionsAsync(Patient.UserId);
            Prescriptions = new ObservableCollection<prescription>(list);
            OnPropertyChanged(nameof(IsEmpty));
        }
        finally
        {
            IsBusy = false;
            OnPropertyChanged(nameof(IsEmpty));
        }
    }

    public bool IsEmpty => Prescriptions == null || Prescriptions.Count == 0;

    
    [RelayCommand]
    private async Task AddMedicineAsync()
    {
        if (Patient == null) return;

        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        await Shell.Current.GoToAsync(nameof(PrescriptionEditPage), new Dictionary<string, object>
        {
            ["PatientId"] = Patient.UserId
        });
    }

    /// <summary>
    /// Удаление (отвязка) пациента из списка врача прямо из карточки
    /// </summary>
    [RelayCommand]
    private async Task DeletePatientAsync()
    {
        if (Patient == null) return;

        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        var confirm = await Shell.Current.DisplayAlert(
            "Подтверждение",
            $"Удалить пациента {Patient.LastName} {Patient.FirstName} из вашего списка?",
            "Удалить",
            "Отмена");

        if (!confirm) return;

        try
        {
            await _userService.RemovePatientFromDoctorListAsync(doctor.UserId, Patient.UserId);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
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
    
    [RelayCommand]
    private async Task EditPrescriptionAsync(prescription p)
    {
        if (Patient == null || p == null) return;

        await Shell.Current.GoToAsync(nameof(PrescriptionEditPage), new Dictionary<string, object>
        {
            ["PatientId"] = Patient.UserId,
            ["PrescriptionId"] = p.PrescriptionId
        });
    }
}
