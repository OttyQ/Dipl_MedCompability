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
        IUserSessionService session)
    {
        _prescriptionService = prescriptionService;
        _interactionService = interactionService;
        _medicineService = medicineService;
        _scanService = scanService;
        _session = session;
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
        }
        finally
        {
            IsBusy = false;
        }
    }
    
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
