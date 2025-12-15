using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;
using MedCompatibility.Pages.Patient;

namespace MedCompatibility.ViewModels.Patient;

public partial class HistoryViewModel : ObservableObject
{
    private readonly IScanService _scanService;
    private readonly IUserSessionService _sessionService;

    [ObservableProperty]
    private ObservableCollection<scan> historyItems = new();

    [ObservableProperty]
    private bool isGuest;

    [ObservableProperty]
    private bool isUser;

    [ObservableProperty]
    private bool isBusy;

    public HistoryViewModel(IScanService scanService, IUserSessionService sessionService)
    {
        _scanService = scanService;
        _sessionService = sessionService;
    }

    [RelayCommand]
    public async Task LoadHistoryAsync()
    {
        // 1. Проверяем роль
        IsGuest = _sessionService.IsGuest;
        IsUser = !IsGuest;

        if (IsGuest)
        {
            HistoryItems.Clear();
            return;
        }

        // 2. Если пользователь, грузим историю
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var list = await _scanService.GetUserHistoryAsync();
            HistoryItems = new ObservableCollection<scan>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось загрузить историю: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        // Если гость нажал "Войти" -> кидаем его на страницу входа
        // Используем абсолютный путь, чтобы сбросить навигационный стек или просто на Login
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoToDetailsAsync(scan historyItem)
    {
        if (historyItem?.Medicine == null) return;

        var navParam = new Dictionary<string, object>
        {
            { "Medicine", historyItem.Medicine }
        };

        await Shell.Current.GoToAsync(nameof(MedicineDetailsPage), navParam);
    }
}