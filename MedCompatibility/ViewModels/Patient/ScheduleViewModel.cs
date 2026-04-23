using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ScheduleViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;

    [ObservableProperty] private DateTime _selectedDate = DateTime.Today;
    [ObservableProperty] private ObservableCollection<DateTime> _weekDays = new();
    [ObservableProperty] private string _monthYearLabel = string.Empty;

    public ScheduleViewModel(IUserSessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [RelayCommand]
    public Task InitializeAsync()
    {
        BuildWeek(SelectedDate);
        return Task.CompletedTask;
    }

    [RelayCommand]
    private void PreviousWeek()
    {
        SelectedDate = SelectedDate.AddDays(-7);
        BuildWeek(SelectedDate);
    }

    [RelayCommand]
    private void NextWeek()
    {
        SelectedDate = SelectedDate.AddDays(7);
        BuildWeek(SelectedDate);
    }

    [RelayCommand]
    public void SelectDate(DateTime date)
    {
        SelectedDate = date.Date;
        BuildWeek(SelectedDate);
    }

    private static string CapitalizeFirst(string s) =>
        string.IsNullOrEmpty(s) ? s : char.ToUpper(s[0]) + s.Substring(1);

    private void BuildWeek(DateTime anchorDate)
    {
        int diff = ((int)anchorDate.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
        var monday = anchorDate.AddDays(-diff);

        WeekDays = new ObservableCollection<DateTime>(
            Enumerable.Range(0, 7).Select(i => monday.AddDays(i)));

        var first = WeekDays.First();
        var last = WeekDays.Last();

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
