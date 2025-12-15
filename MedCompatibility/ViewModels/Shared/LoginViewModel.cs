using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Services.Interfaces; // Убедись, что неймспейс верный

namespace MedCompatibility.ViewModels.Shared;

public partial class LoginViewModel : ObservableObject
{
    private readonly IDatabaseHealthService _dbHealth;
    private readonly IAuthService _authService;
    private readonly ILoadingService _loading;
    // 1. Сервис сессии уже был у тебя в конструкторе, отлично
    private readonly IUserSessionService _sessionService;

    [ObservableProperty]
    private string login;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string errorMessage;

    [ObservableProperty]
    private bool isErrorVisible;
    
    [ObservableProperty] private bool isDbWarningVisible;
    [ObservableProperty] private string? dbWarningText;
    [ObservableProperty] private bool isDbAvailable = true;
    
    [ObservableProperty]
    private bool isPasswordHidden = true;

    [ObservableProperty] private string eyeIconText = "🙈";

    public LoginViewModel(IAuthService authService, IDatabaseHealthService dbHealth, ILoadingService loading, IUserSessionService sessionService)
    {
        _authService = authService;
        _dbHealth = dbHealth;
        _loading = loading;
        _sessionService = sessionService;
    }
    
    public async Task OnAppearingAsync()
    {
        try
        {
            _loading.Show();
            
            await _dbHealth.CheckAsync();
            
            IsDbAvailable = _dbHealth.IsAvailable;
            IsDbWarningVisible = !_dbHealth.IsAvailable;
            DbWarningText = _dbHealth.LastErrorShort;
        }
        finally
        {
            _loading.Hide();
        }
    }
    
    [RelayCommand]
    private async Task ShowDbDetailsAsync()
    {
        var shortMsg = _dbHealth.LastErrorShort ?? "База данных сейчас недоступна.";
        var details  = _dbHealth.LastErrorDetails ?? "Детали недоступны (ошибка не была получена).";

        await Shell.Current.ShowPopupAsync(
            new MedCompatibility.Pages.Shared.Popups.DbUnavailablePopup(shortMsg, details));
    }
    
    [RelayCommand]
    private async Task LoginAsync()
    {
        try
        {
            _loading.Show();
            IsErrorVisible = false;

            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password)) 
                return;

            if (!_dbHealth.IsAvailable) 
            {
                await _dbHealth.CheckAsync(); 
            }

            if (!_dbHealth.IsAvailable)
            {
                IsErrorVisible = true;
                ErrorMessage = "База данных недоступна. Попробуйте позже или войдите как гость.";
                return;
            }

            var user = await _authService.LoginAsync(Login, Password);

            if (user == null)
            {
                ErrorMessage = "Неверный логин или пароль";
                IsErrorVisible = true;
                return;
            }
        
            if (user.IsApproved != true) 
            {
                ErrorMessage = "Аккаунт неподтвержден или заблокирован!";
                IsErrorVisible = true;
                return; 
            }

            // --- НОВОЕ: Сохраняем сессию ---
            _sessionService.StartSession(user);
            // -------------------------------
        
            if (user.Role?.Name.ToLower() == "admin")
                await Shell.Current.GoToAsync("//Admin"); 
            else if (user.Role?.Name.ToLower() == "doctor")
                await Shell.Current.GoToAsync("//Doctor");
            else
                await Shell.Current.GoToAsync("//Patient");

            // --- НОВОЕ: Очищаем поля ПОСЛЕ успешного перехода ---
            // Делаем это, чтобы при нажатии "Выход" форма была пустой
            Login = string.Empty;
            Password = string.Empty;
            IsErrorVisible = false;
        }
        catch (Exception ex)
        {
            ErrorMessage = "Ошибка входа: " + ex.Message;
            IsErrorVisible = true;
        }
        finally
        {
            _loading.Hide();
        }
    }


    [RelayCommand]
    private async Task GoToRegisterAsync()
    {
        await Shell.Current.GoToAsync(nameof(Pages.Shared.RegisterPage)); 
    }

    [RelayCommand]
    private async Task GuestLoginAsync()
    {
        _sessionService.EndSession();
        await Shell.Current.GoToAsync("//Patient");
    }
    
    [RelayCommand]
    private void TogglePasswordVisibility()
    {
        IsPasswordHidden = !IsPasswordHidden;
        EyeIconText = IsPasswordHidden ? "🙈" : "🙉"; 
    }
}
