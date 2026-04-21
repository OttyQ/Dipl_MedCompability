using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views; 
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Models;
using MedCompatibility.Pages.Shared.Popups; 

namespace MedCompatibility.ViewModels.Patient;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly IUserService _userService;
    private readonly IMedicineService _medicineService; // Добавлено для поиска веществ

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    private string roleName;

    [ObservableProperty]
    private bool isGuest;

    [ObservableProperty]
    private bool isUser;
    
    [ObservableProperty]
    private bool showBackButton;

    // --- Поля для редактирования ---
    [ObservableProperty]
    private string editFirstName;
    
    [ObservableProperty]
    private string editLastName;
    
    [ObservableProperty]
    private string editMiddleName;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotEditing))]
    private bool isEditing;
    
    public bool IsNotEditing => !IsEditing;

    // --- Блок полей для аллергий ---
    
    [ObservableProperty]
    private ObservableCollection<activesubstance> _allergies = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddAllergyCommand))]
    [NotifyCanExecuteChangedFor(nameof(RemoveAllergyCommand))]
    private bool _isPatient;

    // Обновленный конструктор с IMedicineService
    public ProfileViewModel(IUserSessionService sessionService, IUserService userService, IMedicineService medicineService)
    {
        _sessionService = sessionService;
        _userService = userService;
        _medicineService = medicineService;
    }

    [RelayCommand]
    public void LoadProfile()
    {
        IsGuest = _sessionService.IsGuest;
        IsUser = !IsGuest;
    
        ShowBackButton = Shell.Current.Navigation.NavigationStack.Count > 1;
        IsEditing = false;

        if (IsUser && _sessionService.CurrentUser != null)
        {
            var user = _sessionService.CurrentUser;
        
            FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim();
            RoleName = user.Role?.Description ?? "Пользователь";

            EditFirstName = user.FirstName;
            EditLastName = user.LastName;
            EditMiddleName = user.MiddleName;

            // Определяем, является ли пользователь пациентом 
            // (Замените "Patient" на системное имя роли пациента в вашей БД)
            IsPatient = user.Role?.Name?.ToLower() == "patient";

            // Если это пациент, асинхронно подгружаем его аллергии
            if (IsPatient)
            {
                _ = LoadAllergiesAsync();
            }
        }
        else
        {
            FullName = "Гость";
            RoleName = "Ограниченный доступ";
            IsPatient = false;
            Allergies?.Clear();
        }
    }

    // --- Логика аллергий ---

    private async Task LoadAllergiesAsync()
    {
        if (!IsPatient || _sessionService.CurrentUser == null) return;

        var list = await _userService.GetUserAllergiesAsync(_sessionService.CurrentUser.UserId);
        
        // Обновляем UI в главном потоке на всякий случай
        MainThread.BeginInvokeOnMainThread(() => 
        {
            Allergies = new ObservableCollection<activesubstance>(list);
        });
    }

    [RelayCommand(CanExecute = nameof(IsPatient))]
    private async Task AddAllergyAsync()
    {
        if (!IsPatient || _sessionService.CurrentUser == null) return;

        var popup = new UniversalSearchPopup(_medicineService, null, SearchMode.Вещество, showAddSection: false, showHistoryTab: false);
        var result = await Shell.Current.ShowPopupAsync(popup);

        if (result is activesubstance selectedSubstance)
        {
            if (!Allergies.Any(a => a.SubstanceId == selectedSubstance.SubstanceId))
            {
                await _userService.AddUserAllergyAsync(_sessionService.CurrentUser.UserId, selectedSubstance.SubstanceId);
                Allergies.Add(selectedSubstance);
            }
            else
            {
                await Shell.Current.DisplayAlert("Внимание", "Это вещество уже есть в списке непереносимости.", "OK");
            }
        }
    }

    [RelayCommand(CanExecute = nameof(IsPatient))]
    private async Task RemoveAllergyAsync(activesubstance item)
    {
        if (!IsPatient || item == null || _sessionService.CurrentUser == null) return;

        bool confirm = await Shell.Current.DisplayAlert("Удаление", $"Удалить {item.Name} из списка непереносимости?", "Да", "Нет");
        if (!confirm) return;

        await _userService.RemoveUserAllergyAsync(_sessionService.CurrentUser.UserId, item.SubstanceId);
        Allergies.Remove(item);
    }

    // --- Существующие команды ---

    [RelayCommand]
    private void StartEditing()
    {
        IsEditing = true;
    }

    [RelayCommand]
    private void CancelEditing()
    {
        LoadProfile(); 
    }

    [RelayCommand]
    private async Task SaveChangesAsync()
    {
        if (IsGuest) return;
        
        if (string.IsNullOrWhiteSpace(EditFirstName) || string.IsNullOrWhiteSpace(EditLastName))
        {
            await Shell.Current.DisplayAlert("Ошибка", "Имя и Фамилия обязательны", "OK");
            return;
        }

        try
        {
            var currentUser = _sessionService.CurrentUser;
            if (currentUser == null) return;

            await _userService.UpdateUserProfileAsync(currentUser.UserId, EditFirstName, EditLastName, EditMiddleName);

            currentUser.FirstName = EditFirstName;
            currentUser.LastName = EditLastName;
            currentUser.MiddleName = EditMiddleName;
            
            LoadProfile();
            
            await Shell.Current.DisplayAlert("Успех", "Данные обновлены", "OK");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось сохранить: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        bool confirm = await Shell.Current.DisplayAlert("Выход", "Вы уверены, что хотите выйти?", "Да", "Нет");
        if (!confirm) return;

        _sessionService.EndSession();
        Application.Current.MainPage = new AppShell();
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}