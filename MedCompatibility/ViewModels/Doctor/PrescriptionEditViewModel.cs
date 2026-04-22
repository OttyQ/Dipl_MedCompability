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
    private readonly IUserService _userService;

    private int _patientId;
    private int? _prescriptionId;

    private string _startDate = "";
    public string StartDate
    {
        get => _startDate;
        set
        {
            if (SetProperty(ref _startDate, value))
            {
                if (DateTime.TryParseExact(value, new[] { "dd.MM.yyyy", "d.M.yyyy", "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yy" }, null, System.Globalization.DateTimeStyles.None, out var d))
                {
                    _startDatePickerBackup = d;
                    OnPropertyChanged(nameof(StartDatePickerValue));
                }
            }
        }
    }

    private string _endDate = "";
    public string EndDate
    {
        get => _endDate;
        set
        {
            if (SetProperty(ref _endDate, value))
            {
                if (DateTime.TryParseExact(value, new[] { "dd.MM.yyyy", "d.M.yyyy", "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yy" }, null, System.Globalization.DateTimeStyles.None, out var d))
                {
                    _endDatePickerBackup = d;
                    OnPropertyChanged(nameof(EndDatePickerValue));
                }
            }
        }
    }

    private DateTime _startDatePickerBackup = DateTime.Today;
    public DateTime StartDatePickerValue
    {
        get => _startDatePickerBackup;
        set
        {
            if (SetProperty(ref _startDatePickerBackup, value))
            {
                StartDate = value.ToString("dd.MM.yyyy");
            }
        }
    }

    private DateTime _endDatePickerBackup = DateTime.Today;
    public DateTime EndDatePickerValue
    {
        get => _endDatePickerBackup;
        set
        {
            if (SetProperty(ref _endDatePickerBackup, value))
            {
                EndDate = value.ToString("dd.MM.yyyy");
            }
        }
    }

    [ObservableProperty] private medicine? selectedMedicine;
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

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("PatientId", out var pObj) && pObj is int pid)
            _patientId = pid;

        if (query.TryGetValue("PrescriptionId", out var prObj) && prObj is int prid)
            _prescriptionId = prid;

        // Обработка перехода с выбранным лекарством из карточки пациента (добавлено)
        if (query.TryGetValue("MedicineId", out var mObj) && mObj is int mid)
        {
            var med = await _medicineService.GetMedicineByIdAsync(mid);
            if (med != null)
                await TryApplyMedicineAsync(med);
        }

        // Возврат из CodeScannerPage
        if (query.TryGetValue("ScannedCode", out var scObj))
        {
            var code = scObj?.ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                var med = await _medicineService.GetMedicineByGtinAsync(code);
                if (med != null)
                {
                    // 3. ДОБАВЛЕНО: Проверяем аллергию даже после сканирования
                    await TryApplyMedicineAsync(med); 
                }
                else
                {
                    await Shell.Current.DisplayAlert("Не найдено", $"Препарат по коду {code} не найден.", "OK");
                }
            }
        }

        query.Clear();

        if (IsEditMode)
            await LoadForEditAsync();
        else
        {
            // Устанавливаем даты по умолчанию для нового назначения
            StartDate = DateTime.Today.ToString("dd.MM.yyyy");
            EndDate = DateTime.Today.AddDays(7).ToString("dd.MM.yyyy");
        }

        OnPropertyChanged(nameof(IsEditMode));
        OnPropertyChanged(nameof(PageTitle));
    }

    
    private async Task TryApplyMedicineAsync(medicine med)
    {
        if (med == null) return;

        // Убеждаемся, что у лекарства подгружен состав
        var medWithSubstances = await _medicineService.GetMedicineByIdAsync(med.MedicineId);
        
        // Получаем аллергии пациента
        var patientAllergies = await _userService.GetUserAllergiesAsync(_patientId);
        
        // Ищем пересечения
        if (medWithSubstances?.Substances != null && patientAllergies.Any())
        {
            var intersectingSubstances = medWithSubstances.Substances
                .Where(s => patientAllergies.Any(a => a.SubstanceId == s.SubstanceId))
                .ToList();

            if (intersectingSubstances.Any())
            {
                var conflictNames = string.Join(", ", intersectingSubstances.Select(s => s.Name));
                await Shell.Current.DisplayAlert(
                    "Аллергическая реакция!", 
                    $"Препарат «{med.TradeName}» нельзя назначить.\nОн содержит непереносимые пациентом вещества:\n\n{conflictNames}", 
                    "Отмена");
                
                return; // Блокируем назначение
            }
        }

        // Если аллергий нет - применяем
        SelectedMedicine = medWithSubstances ?? med;
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
        StartDate = p.StartDate.ToString("dd.MM.yyyy");
        EndDate = p.EndDate.ToString("dd.MM.yyyy");
        Dosage = p.Dosage ?? "";
        Notes = p.Notes;
    }
    
    [RelayCommand]
    private async Task PickMedicineAsync()
    {
        // Врач выбирает лекарство — история скрыта (showHistoryTab: false)
        var popup = new UniversalSearchPopup(
            _medicineService,
            _scanService,
            SearchMode.Лекарство,
            showAddSection: false,
            showHistoryTab: false);

        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is string action && action == "SCAN")
        {
            await Shell.Current.GoToAsync(nameof(CodeScannerPage));
            return;
        }

        if (result is medicine med)
        {
            // ИСПОЛЬЗУЕМ НАШ МЕТОД ПРОВЕРКИ АЛЛЕРГИИ ВМЕСТО ПРЯМОГО ПРИСВОЕНИЯ
            await TryApplyMedicineAsync(med);
        }
    }

    private bool Validate()
    {
        HasError = false;
        ErrorText = "";

        if (SelectedMedicine == null)
            return Fail("Выберите препарат.");

        if (string.IsNullOrWhiteSpace(Dosage))
            return Fail("Укажите дозировку.");

        var formats = new[] { "dd.MM.yyyy", "d.M.yyyy", "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yy" };

        if (!DateTime.TryParseExact(StartDate, formats, null, System.Globalization.DateTimeStyles.None, out var sDate))
            return Fail("Введите корректную дату начала (ДД.ММ.ГГГГ).");

        if (!DateTime.TryParseExact(EndDate, formats, null, System.Globalization.DateTimeStyles.None, out var eDate))
            return Fail("Введите корректную дату окончания (ДД.ММ.ГГГГ).");

        if (sDate.Date > eDate.Date)
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
        var current = await _prescriptionService.GetPatientPrescriptionsAsync(_patientId); 

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

        var isCritical = allConflicts.Any(c => (c.RiskLevel?.Severity ?? 0) >= 3); 

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
        
        if (!await ConfirmIfConflictsAsync(SelectedMedicine!.MedicineId))
            return;

        try
        {
            var formats = new[] { "dd.MM.yyyy", "d.M.yyyy", "dd.M.yyyy", "d.MM.yyyy", "dd.MM.yy" };
            var parsedStart = DateTime.ParseExact(StartDate, formats, null, System.Globalization.DateTimeStyles.None);
            var parsedEnd = DateTime.ParseExact(EndDate, formats, null, System.Globalization.DateTimeStyles.None);

            if (!IsEditMode)
            {
                await _prescriptionService.CreateAsync(
                    _patientId,
                    doctor.UserId,
                    SelectedMedicine!.MedicineId,
                    parsedStart,
                    parsedEnd,
                    Dosage.Trim(),
                    string.IsNullOrWhiteSpace(Notes) ? null : Notes.Trim());
            }
            else
            {
                await _prescriptionService.UpdateAsync(
                    _prescriptionId!.Value,
                    doctor.UserId,
                    SelectedMedicine!.MedicineId,
                    parsedStart,
                    parsedEnd,
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
