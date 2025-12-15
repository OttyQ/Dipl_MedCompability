using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Patient;

public partial class ProfileViewModel : ObservableObject
{
    private readonly IUserSessionService _sessionService;
    private readonly IUserService _userService; // Добавляем сервис для сохранения

    [ObservableProperty]
    private string fullName;

    [ObservableProperty]
    private string roleName;

    [ObservableProperty]
    private bool isGuest;

    [ObservableProperty]
    private bool isUser;

    // --- Поля для редактирования ---
    [ObservableProperty]
    private string editFirstName;
    
    [ObservableProperty]
    private string editLastName;
    
    [ObservableProperty]
    private string editMiddleName;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotEditing))] // Чтобы инвертировать видимость
    private bool isEditing;

    public bool IsNotEditing => !IsEditing;
    // -------------------------------

    public ProfileViewModel(IUserSessionService sessionService, IUserService userService)
    {
        _sessionService = sessionService;
        _userService = userService;
    }

    [RelayCommand]
    public void LoadProfile()
    {
        IsGuest = _sessionService.IsGuest;
        IsUser = !IsGuest;
        IsEditing = false; // Сбрасываем режим редактирования при входе

        if (IsUser && _sessionService.CurrentUser != null)
        {
            var user = _sessionService.CurrentUser;
            
            // Заполняем отображение
            FullName = $"{user.LastName} {user.FirstName} {user.MiddleName}".Trim();
            RoleName = user.Role?.Description ?? "Пользователь";

            // Заполняем поля для возможного редактирования
            EditFirstName = user.FirstName;
            EditLastName = user.LastName;
            EditMiddleName = user.MiddleName;
        }
        else
        {
            FullName = "Гость";
            RoleName = "Ограниченный доступ";
        }
    }

    [RelayCommand]
    private void StartEditing()
    {
        IsEditing = true;
    }

    [RelayCommand]
    private void CancelEditing()
    {
        // Возвращаем старые значения
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

            // 1. Сохраняем в БД
            await _userService.UpdateUserProfileAsync(currentUser.UserId, EditFirstName, EditLastName, EditMiddleName);

            // 2. Обновляем локальную сессию (объект в памяти)
            currentUser.FirstName = EditFirstName;
            currentUser.LastName = EditLastName;
            currentUser.MiddleName = EditMiddleName;
            
            // 3. Обновляем UI
            LoadProfile(); // Перезагрузит FullName и сбросит IsEditing
            
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
        await Shell.Current.GoToAsync("//Login");
    }
    
    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await Shell.Current.GoToAsync("//Login");
    }
}
