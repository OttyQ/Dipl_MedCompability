using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Admin;

public partial class UsersListViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly ILoadingService _loading;

    [ObservableProperty]
    private ObservableCollection<user> users = new();

    [ObservableProperty] 
    private string searchText;

    [ObservableProperty] 
    private string selectedRole = "Все";
    
    [ObservableProperty] 
    private string selectedStatus = "Все";

    public List<string> Roles { get; } = new() { "Все", "Врачи", "Пациенты", "Админы" };
    public List<string> Statuses { get; } = new() { "Все", "Активные", "Заблокированные" };

    public UsersListViewModel(IUserService userService, ILoadingService loading)
    {
        _userService = userService;
        _loading = loading;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        try
        {
            _loading.Show();
            var list = await _userService.GetUsersFilteredAsync(SearchText, SelectedRole, SelectedStatus);
            Users = new ObservableCollection<user>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task DeleteUserAsync(user u)
    {
        if (u == null) return;

        var confirm = await Shell.Current.ShowPopupAsync(
            new Pages.Shared.Popups.ConfirmPopup(
                "Удаление", 
                $"Удалить пользователя {u.Login}?", 
                okText: "Удалить", 
                cancelText: "Отмена"));

        if (confirm is bool ok && ok)
        {
            try
            {
                _loading.Show();
                await _userService.DeleteUserAsync(u.UserId);
                await LoadDataAsync();
            }
            finally
            {
                _loading.Hide();
            }
        }
    }

    [RelayCommand]
    private async Task ToggleStatusAsync(user u)
    {
        if (u == null) return;
        try
        {
            bool newStatus = !(u.IsApproved ?? false);
            await _userService.ToggleUserStatusAsync(u.UserId, newStatus);
            await LoadDataAsync(); // Обновляем список чтобы показать актуальное состояние
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }
    
    [RelayCommand]
    private async Task ResetFiltersAsync()
    {
        SearchText = string.Empty;
        SelectedRole = "Все";
        SelectedStatus = "Все";
    
        // Сразу перезагружаем список
        await LoadDataAsync();
    }
    
    // Вызывается при изменении фильтров
    partial void OnSelectedRoleChanged(string value) => LoadDataCommand.Execute(null);
    partial void OnSelectedStatusChanged(string value) => LoadDataCommand.Execute(null);
}
