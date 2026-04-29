using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.ViewModels.Admin;

public partial class SystemLogsViewModel : ObservableObject
{
    private readonly IAppLogService _logService;
    private readonly IDatabaseHealthService _dbHealth;
    private readonly IAiHealthService _aiHealth;

    [ObservableProperty] private ObservableCollection<SystemLog> recentLogs = new();
    [ObservableProperty] private bool isBusy;
    
    [ObservableProperty] private string dbStatusText = "Проверка...";
    [ObservableProperty] private Color dbStatusColor = Colors.Gray;

    [ObservableProperty] private string aiStatusText = "Проверка...";
    [ObservableProperty] private Color aiStatusColor = Colors.Gray;
    [ObservableProperty] private string aiLatency = "";

    public SystemLogsViewModel(IAppLogService logService, IDatabaseHealthService dbHealth, IAiHealthService aiHealth)
    {
        _logService = logService;
        _dbHealth = dbHealth;
        _aiHealth = aiHealth;
    }

    [RelayCommand]
    public async Task LoadLogsAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var dbTask = _dbHealth.CheckAsync();
            var aiTask = _aiHealth.CheckAsync();
            await Task.WhenAll(dbTask, aiTask);

            DbStatusText = _dbHealth.IsAvailable ? "БД: Подключено" : "БД: Ошибка";
            DbStatusColor = _dbHealth.IsAvailable ? Colors.Green : Colors.Red;

            if (_aiHealth.IsAvailable)
            {
                AiStatusText = "ИИ: Готов к работе";
                AiStatusColor = Colors.Green;
                AiLatency = $"{_aiHealth.Latency} мс";
            }
            else
            {
                AiStatusText = "ИИ: Недоступен";
                AiStatusColor = Colors.Red;
                AiLatency = "-";
            }

            var list = await _logService.GetRecentLogsAsync(50);
            RecentLogs = new ObservableCollection<SystemLog>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка загрузки", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}