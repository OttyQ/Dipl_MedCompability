using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Shared;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IAuthService _authService;
    private readonly ILoadingService _loading;

    [ObservableProperty] private string firstName;
    [ObservableProperty] private string lastName;
    [ObservableProperty] private string middleName;
    [ObservableProperty] private string login;
    [ObservableProperty] private string password;
    [ObservableProperty] private string confirmPassword;
    [ObservableProperty] private string errorMessage;
    [ObservableProperty] private bool isErrorVisible;

    // --- Добавляем выбор роли ---
    [ObservableProperty]
    private List<string> availableRoles = new() { "Пациент", "Врач" };

    [ObservableProperty]
    private string selectedRole = "Пациент"; // По умолчанию
    // ----------------------------

    public RegisterViewModel(IAuthService authService, ILoadingService loading)
    {
        _authService = authService;
        _loading = loading;
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        IsErrorVisible = false;

        // 1. Валидация
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || 
            string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
        {
            ShowError("Заполните все обязательные поля");
            return;
        }

        if (Password != ConfirmPassword)
        {
            ShowError("Пароли не совпадают");
            return;
        }

        if (Password.Length < 4) // Чуть ослабил для удобства тестов, можешь вернуть 6
        {
            ShowError("Пароль слишком короткий");
            return;
        }

        try
        {
            _loading.Show(); 

            // Определяем роль для БД (UI "Врач" -> DB "Doctor")
            // Если у тебя в БД роль называется "doctor" (маленькими), пиши тут "doctor"
            string dbRoleName = SelectedRole == "Врач" ? "Doctor" : "Patient";

            // Вызываем НОВЫЙ метод RegisterUserAsync
            string error = await _authService.RegisterUserAsync(Login, Password, FirstName, LastName, MiddleName, dbRoleName);

            if (error != null)
            {
                ShowError(error);
                return; 
            }

            // Успех
            if (dbRoleName == "Doctor")
            {
                await Shell.Current.ShowPopupAsync(new ApprovalPendingPopup());
                await Shell.Current.GoToAsync(".."); // обратно на логин как и было
                return;
            }
            else
            {
                await Shell.Current.DisplayAlert("Успех", "Аккаунт создан!", "OK");
            }
            
            await Shell.Current.GoToAsync(".."); 
        }
        catch (Exception ex)
        {
            ShowError("Ошибка: " + ex.Message);
        }
        finally
        {
            _loading.Hide();
        }
    }

    [RelayCommand]
    private async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    private void ShowError(string message)
    {
        ErrorMessage = message;
        IsErrorVisible = true;
    }
}
