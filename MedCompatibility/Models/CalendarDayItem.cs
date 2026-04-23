using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MedCompatibility.Models;

public partial class CalendarDayItem : ObservableObject
{
    public DateTime Date { get; set; }
    public DayType Type { get; set; }
    
    [ObservableProperty] 
    private bool _isSelected;
}
