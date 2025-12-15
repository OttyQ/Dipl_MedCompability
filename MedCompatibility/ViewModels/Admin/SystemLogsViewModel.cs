using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.ViewModels.Admin;

public partial class SystemLogsViewModel : ObservableObject
{
    private readonly IScanService _scanService;
    private readonly IDatabaseHealthService _dbHealth;

    [ObservableProperty]
    private ObservableCollection<scan> logs = new();

    [ObservableProperty]
    private bool isBusy;
    
    [ObservableProperty]
    private string dbStatusText;

    [ObservableProperty]
    private Color dbStatusColor;

    public SystemLogsViewModel(IScanService scanService, IDatabaseHealthService dbHealth)
    {
        _scanService = scanService;
        _dbHealth = dbHealth;
    }

    [RelayCommand]
    public async Task LoadLogsAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            // 1. Обновляем статус БД
            await _dbHealth.CheckAsync();
            if (_dbHealth.IsAvailable)
            {
                DbStatusText = "База данных: Подключено";
                DbStatusColor = Colors.Green;
            }
            else
            {
                DbStatusText = "База данных: Ошибка соединения";
                DbStatusColor = Colors.Red;
            }

            // 2. Грузим логи
            var list = await _scanService.GetAllScansAsync();
            Logs = new ObservableCollection<scan>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}