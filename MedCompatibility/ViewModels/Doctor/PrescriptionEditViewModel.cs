using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Doctor;

public partial class PrescriptionEditViewModel : ObservableObject, IQueryAttributable
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;
    private readonly IUserSessionService _session;

    private int _patientId;
    private int? _prescriptionId;

    [ObservableProperty] private medicine? selectedMedicine;
    [ObservableProperty] private DateTime startDate = DateTime.Today;
    [ObservableProperty] private DateTime endDate = DateTime.Today;
    [ObservableProperty] private string dosage = "";
    [ObservableProperty] private string? notes;

    [ObservableProperty] private bool hasError;
    [ObservableProperty] private string errorText = "";

    public bool IsEditMode => _prescriptionId.HasValue;
    public string PageTitle => IsEditMode ? "Редактирование" : "Новое назначение";

    public PrescriptionEditViewModel(
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

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("PatientId", out var pObj) && pObj is int pid)
            _patientId = pid;

        if (query.TryGetValue("PrescriptionId", out var prObj) && prObj is int prid)
            _prescriptionId = prid;

        // Возврат из CodeScannerPage: { "ScannedCode" : "..." } [file:58]
        if (query.TryGetValue("ScannedCode", out var scObj))
        {
            var code = scObj?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                var med = await _medicineService.GetMedicineByGtinAsync(code);
                if (med != null)
                    SelectedMedicine = med;
                else
                    await Shell.Current.DisplayAlert("Не найдено", $"Препарат по коду {code} не найден.", "OK");
            }
        }

        query.Clear();

        if (IsEditMode)
            await LoadForEditAsync();

        OnPropertyChanged(nameof(IsEditMode));
        OnPropertyChanged(nameof(PageTitle));
    }

    private async Task LoadForEditAsync()
    {
        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        var p = await _prescriptionService.GetByIdAsync(_prescriptionId!.Value);
        if (p == null)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Назначение не найдено.", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        if (p.DoctorId != doctor.UserId)
        {
            await Shell.Current.DisplayAlert("Доступ запрещён", "Редактировать может только автор назначения.", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        SelectedMedicine = p.Medicine;
        StartDate = p.StartDate;
        EndDate = p.EndDate;
        Dosage = p.Dosage ?? "";
        Notes = p.Notes;
    }

    [RelayCommand]
    private async Task PickMedicineAsync()
    {
        var popup = new MedicineSelectionPopup(_medicineService, _scanService);
        var result = await Shell.Current.ShowPopupAsync(popup);

        // В попапе Scan = Close("SCAN") [file:58]
        if (result is string action && action == "SCAN")
        {
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
            return;
        }

        if (result is medicine med)
            SelectedMedicine = med;
    }

    private bool Validate()
    {
        HasError = false;
        ErrorText = "";

        if (SelectedMedicine == null)
            return Fail("Выберите препарат.");

        if (string.IsNullOrWhiteSpace(Dosage))
            return Fail("Укажите дозировку.");

        if (StartDate.Date > EndDate.Date)
            return Fail("Дата начала не может быть позже даты окончания.");

        return true;

        bool Fail(string text)
        {
            HasError = true;
            ErrorText = text;
            return false;
        }
    }

    private async Task<bool> ConfirmIfConflictsAsync(int selectedMedicineId)
    {
        var current = await _prescriptionService.GetPatientPrescriptionsAsync(_patientId); // [file:58]

        // Если редактируем — исключаем текущее назначение из сравнения
        if (IsEditMode)
            current = current.Where(p => p.PrescriptionId != _prescriptionId!.Value).ToList();

        var allConflicts = new List<interaction>();

        foreach (var p in current)
        {
            if (p.MedicineId == selectedMedicineId) continue;

            var conflicts = await _interactionService.CheckInteractionAsync(p.MedicineId, selectedMedicineId); // [file:58]
            if (conflicts != null && conflicts.Count > 0)
                allConflicts.AddRange(conflicts);
        }

        // Чтобы не дублировать одинаковые interaction, если прилетели повторно
        allConflicts = allConflicts
            .GroupBy(x => x.InteractionId)
            .Select(g => g.First())
            .ToList();

        if (!allConflicts.Any())
            return true;

        var isCritical = allConflicts.Any(c => (c.RiskLevel?.Severity ?? 0) >= 3); // [file:58]

        var result = await Shell.Current.ShowPopupAsync(
            new InteractionsDetailsPopup(allConflicts, isCritical));

        return result is bool ok && ok;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (!Validate()) return;

        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        // ВОССТАНОВЛЕНО: проверяем взаимодействия перед сохранением [file:58]
        if (!await ConfirmIfConflictsAsync(SelectedMedicine!.MedicineId))
            return;

        try
        {
            if (!IsEditMode)
            {
                await _prescriptionService.CreateAsync(
                    _patientId,
                    doctor.UserId,
                    SelectedMedicine!.MedicineId,
                    StartDate,
                    EndDate,
                    Dosage.Trim(),
                    string.IsNullOrWhiteSpace(Notes) ? null : Notes.Trim());
            }
            else
            {
                await _prescriptionService.UpdateAsync(
                    _prescriptionId!.Value,
                    doctor.UserId,
                    SelectedMedicine!.MedicineId,
                    StartDate,
                    EndDate,
                    Dosage.Trim(),
                    string.IsNullOrWhiteSpace(Notes) ? null : Notes.Trim());
            }

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (!IsEditMode) return;

        var doctor = _session.CurrentUser;
        if (doctor == null) return;

        var confirm = await Shell.Current.DisplayAlert("Удаление", "Удалить назначение?", "Да", "Нет");
        if (!confirm) return;

        try
        {
            await _prescriptionService.DeleteAsync(_prescriptionId!.Value, doctor.UserId);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task GoBackAsync() => await Shell.Current.GoToAsync("..");
}
