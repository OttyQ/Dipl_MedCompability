using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ScheduleViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly IPrescriptionService _prescriptionService;
    private List<prescription> _allPrescriptions = new();

    [ObservableProperty] private DateTime _selectedDate = DateTime.Today;
    [ObservableProperty] private ObservableCollection<CalendarDayItem> _weekDays = new();
    [ObservableProperty] private string _monthYearLabel = string.Empty;

    [ObservableProperty] private ObservableCollection<prescription> _prescriptionsForDay = new();
    [ObservableProperty] private bool _isEmpty = true;
    [ObservableProperty] private string _selectedDateSummaryLabel = string.Empty;

    public ScheduleViewModel(IUserSessionService sessionService, IPrescriptionService prescriptionService)
    {
        _sessionService = sessionService;
        _prescriptionService = prescriptionService;
    }

    [RelayCommand]
    public async Task InitializeAsync()
    {
        if (_sessionService.CurrentUser?.UserId > 0)
        {
            _allPrescriptions = await _prescriptionService.GetPatientPrescriptionsAsync(_sessionService.CurrentUser.UserId);
        }
        
        // Перестраиваем неделю и загружаем данные для выбранного дня
        BuildWeek(SelectedDate);
        UpdatePrescriptionsForDate(SelectedDate);
    }

    [RelayCommand]
    private void PreviousWeek()
    {
        if (WeekDays.Any())
        {
            var targetDate = WeekDays.First().Date.AddDays(-7);
            BuildWeek(targetDate);
        }
    }

    [RelayCommand]
    private void NextWeek()
    {
        if (WeekDays.Any())
        {
            var targetDate = WeekDays.First().Date.AddDays(7);
            BuildWeek(targetDate);
        }
    }

    [RelayCommand]
    public void SelectDate(object? arg)
    {
        DateTime date;
        if (arg is CalendarDayItem dayItem)
            date = dayItem.Date.Date;
        else if (arg is DateTime dt)
            date = dt.Date;
        else
            return;

        SelectedDate = date;
        
        // 1. Если выбранная дата не в текущем списке WeekDays, перестраиваем неделю
        if (!WeekDays.Any(d => d.Date.Date == SelectedDate.Date))
        {
            BuildWeek(SelectedDate);
        }
        else
        {
            // Иначе просто обновляем IsSelected в ленте
            foreach (var day in WeekDays)
            {
                day.IsSelected = day.Date.Date == SelectedDate.Date;
            }
        }

        // 2. Фильтрация и обновление списка назначений
        UpdatePrescriptionsForDate(date);
    }

    private void UpdatePrescriptionsForDate(DateTime date)
    {
        // Фильтрация локально — без повторного запроса к БД
        var filtered = _allPrescriptions
            .Where(p => p.StartDate.Date <= date.Date && p.EndDate.Date >= date.Date)
            .ToList();

        PrescriptionsForDay = new ObservableCollection<prescription>(filtered);
        IsEmpty = !PrescriptionsForDay.Any();

        // Формирование строки заголовка (например: "Среда, 22 апреля — 2 назначения")
        string dayName = date.ToString("dddd, d MMMM", new CultureInfo("ru-RU"));
        dayName = char.ToUpper(dayName[0]) + dayName.Substring(1);

        string countText = PrescriptionsForDay.Count switch
        {
            1 => "1 назначение",
            > 1 and < 5 => $"{PrescriptionsForDay.Count} назначения",
            _ => $"{PrescriptionsForDay.Count} назначений"
        };
        SelectedDateSummaryLabel = $"{dayName} — {countText}";

        // Сброс индикатора новых назначений (запись в SecureStorage)
        if (_sessionService.CurrentUser != null && _allPrescriptions.Any(p => p.PrescribedAt.HasValue))
        {
            var maxPrescribedAt = _allPrescriptions
                .Where(p => p.PrescribedAt.HasValue)
                .Max(p => p.PrescribedAt!.Value);
            
            _ = SecureStorage.SetAsync($"last_checked_prescriptions_{_sessionService.CurrentUser.UserId}", maxPrescribedAt.ToString("O"));
        }
    }

    private static string CapitalizeFirst(string s) =>
        string.IsNullOrEmpty(s) ? s : char.ToUpper(s[0]) + s.Substring(1);

    private DayType GetDayType(DateTime date)
    {
        var matching = _allPrescriptions
            .Where(p => p.StartDate.Date <= date.Date && p.EndDate.Date >= date.Date)
            .ToList();

        if (!matching.Any()) return DayType.None;

        bool hasActive = matching.Any(p => p.EndDate.Date >= DateTime.Today);
        bool hasExpired = matching.Any(p => p.EndDate.Date < DateTime.Today);

        if (hasActive)
            return date.Date < DateTime.Today ? DayType.ActivePast : DayType.ActiveFuture;

        if (hasExpired)
            return DayType.Expired;

        return DayType.None;
    }

    private void BuildWeek(DateTime anchorDate)
    {
        int diff = ((int)anchorDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
        var monday = anchorDate.AddDays(-diff);

        var days = Enumerable.Range(0, 7).Select(i => 
        {
            var date = monday.AddDays(i);
            return new CalendarDayItem
            {
                Date = date,
                Type = GetDayType(date),
                IsSelected = date.Date == SelectedDate.Date
            };
        }).ToList();

        WeekDays = new ObservableCollection<CalendarDayItem>(days);

        var first = WeekDays.First().Date;
        var last = WeekDays.Last().Date;

        if (first.Year == last.Year && first.Month == last.Month)
        {
            MonthYearLabel = CapitalizeFirst(first.ToString("MMMM yyyy", new CultureInfo("ru-RU")));
        }
        else if (first.Year == last.Year)
        {
            MonthYearLabel =
                CapitalizeFirst(first.ToString("MMMM", new CultureInfo("ru-RU"))) +
                " — " + CapitalizeFirst(last.ToString("MMMM yyyy", new CultureInfo("ru-RU")));
        }
        else
        {
            MonthYearLabel =
                CapitalizeFirst(first.ToString("MMMM yyyy", new CultureInfo("ru-RU"))) +
                " — " + CapitalizeFirst(last.ToString("MMMM yyyy", new CultureInfo("ru-RU")));
        }
    }
}
