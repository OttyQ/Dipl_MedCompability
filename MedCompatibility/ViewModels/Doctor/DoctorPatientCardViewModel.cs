using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

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

        // Выбор лекарства (у тебя popup уже используется в CompatibilityViewModel) [file:1]
        var popup = new MedicineSelectionPopup(_medicineService, _scanService);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
            return;
        }

        if (result is not medicine selectedMed) return;

        // Берём актуальные назначения и проверяем на конфликты
        var current = await _prescriptionService.GetPatientPrescriptionsAsync(Patient.UserId);
        var allConflicts = new List<interaction>();

        foreach (var p in current)
        {
            if (p.MedicineId == selectedMed.MedicineId) continue;

            var conflicts = await _interactionService.CheckInteractionAsync(p.MedicineId, selectedMed.MedicineId);
            if (conflicts != null && conflicts.Count > 0)
                allConflicts.AddRange(conflicts);
        }

        // Пример правила: Severity >= 3 считаем “критично” (подстрой под свои RiskLevel) [file:1]
        var critical = allConflicts.Any(c => c.RiskLevel?.Severity >= 3);

        if (allConflicts.Any())
        {
            var title = critical ? "Опасная несовместимость" : "Есть взаимодействия";
            var msg = critical
                ? "Найдены критические взаимодействия. Добавить всё равно?"
                : $"Найдены взаимодействия: {allConflicts.Count}. Добавить?";

            var confirm = await Shell.Current.ShowPopupAsync(new ConfirmPopup(title, msg, "Добавить", "Отмена"));
            if (confirm is not bool ok || !ok) return;
        }

        await _prescriptionService.AddPrescriptionAsync(Patient.UserId, doctor.UserId, selectedMed.MedicineId, notes: null);
        await LoadDataAsync();
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
