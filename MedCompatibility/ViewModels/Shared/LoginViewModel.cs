using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Shared;

public partial class LoginViewModel : ObservableObject
{
    
    private readonly IDatabaseHealthService _dbHealth;
    private readonly IAuthService _authService;
    private readonly ILoadingService _loading;
    private readonly IUserSessionService _sessionService;
    private int _googleAttemptId;
    private CancellationTokenSource? _googleUiCts;

    [ObservableProperty] private string login = string.Empty;
    [ObservableProperty] private string password = string.Empty;

    [ObservableProperty] private string errorMessage = string.Empty;
    [ObservableProperty] private bool isErrorVisible;

    [ObservableProperty] private bool isDbWarningVisible;
    [ObservableProperty] private string? dbWarningText;
    [ObservableProperty] private bool isDbAvailable = true;

    [ObservableProperty] private bool isPasswordHidden = true;
    [ObservableProperty] private string eyeIconText = "🙈";
    [ObservableProperty] private bool isAuthInProgress;

    // Согласие на обработку персональных данных (Закон РБ № 99-З)
    [ObservableProperty] private bool isDataProcessingAccepted;

    public bool IsDebugMode =>
#if DEBUG && (ANDROID || WINDOWS)
        true;
#else
        false;
#endif



    public LoginViewModel(
        IAuthService authService,
        IDatabaseHealthService dbHealth,
        ILoadingService loading,
        IUserSessionService sessionService)
    {
        _authService = authService;
        _dbHealth = dbHealth;
        _loading = loading;
        _sessionService = sessionService;
    }

    public async Task OnAppearingAsync()
    {
        // Убрали try-finally и блокирующий лоадер
        // Проверка проходит абсолютно незаметно для пользователя
        await _dbHealth.CheckAsync();

        IsDbAvailable = _dbHealth.IsAvailable;
        IsDbWarningVisible = !_dbHealth.IsAvailable;
        DbWarningText = _dbHealth.LastErrorShort;
    }

    [RelayCommand]
    private async Task ShowDbDetailsAsync()
    {
        var shortMsg = _dbHealth.LastErrorShort ?? "База данных сейчас недоступна.";
        var details = _dbHealth.LastErrorDetails ?? "Детали недоступны (ошибка не была получена).";

        await Shell.Current.ShowPopupAsync(new DbUnavailablePopup(shortMsg, details));
    }

    private void ShowInlineError(string message)
    {
        ErrorMessage = message;
        IsErrorVisible = true;
    }

    /// <returns>true если вход/переход надо остановить (статус обработан)</returns>
    private async Task<bool> HandleNotApprovedAsync(MedCompatibility.Models.user user)
    {
        var role = user.Role?.Name?.ToLower();

        // 1) Врач: ожидает подтверждения
        if (role == "doctor" && user.IsApproved != true)
        {
            // UI через popup
            try
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Shell.Current.ShowPopupAsync(new ApprovalPendingPopup());
                });
            }
            catch
            {
                // fallback
                await Shell.Current.DisplayAlert(
                    "Заявка отправлена",
                    "Аккаунт врача создан и ожидает подтверждения администратором.",
                    "OK");
            }

            return true;
        }

        // 2) Пациент: считаем IsApproved=false как "заблокирован"
        if (role == "patient" && user.IsApproved != true)
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Shell.Current.ShowPopupAsync(new PatientBlockedPopup());
            });

            return true;
        }

        return false;
    }

    private async Task NavigateByRoleAsync(string? roleName)
    {
        roleName = roleName?.ToLower();

        if (roleName == "admin")
            await Shell.Current.GoToAsync("//Admin");
        else if (roleName == "doctor")
            await Shell.Current.GoToAsync("//Doctor");
        else
            await Shell.Current.GoToAsync("//Patient");
    }

    [RelayCommand]
    private async Task OpenDebugPopupAsync()
    {
        var result = await Shell.Current.ShowPopupAsync(new DebugLoginPopup());
        if (result is string role)
        {
            switch (role)
            {
                case "Admin":
                    Login = "admin";
                    Password = "admin123";
                    break;
                case "Doctor":
                    Login = "doctest";
                    Password = "doctest";
                    break;
                case "Patient":
                    Login = "123";
                    Password = "12345";
                    break;
            }
            await LoginAsync();
        }
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
                await _dbHealth.CheckAsync();

            if (!_dbHealth.IsAvailable)
            {
                ShowInlineError("База данных недоступна. Попробуйте позже или войдите как гость.");
                return;
            }

            var user = await _authService.LoginAsync(Login, Password);

            if (user == null)
            {
                ShowInlineError("Неверный логин или пароль");
                return;
            }

            // ВАЖНО: статус проверяем ДО StartSession
            if (await HandleNotApprovedAsync(user))
                return;

            await _sessionService.StartSessionAsync(user);

            await NavigateByRoleAsync(user.Role?.Name);

            // очистка после успешного входа
            Login = string.Empty;
            Password = string.Empty;
            IsErrorVisible = false;
        }
        catch (Exception ex)
        {
            ShowInlineError("Ошибка входа: " + ex.Message);
        }
        finally
        {
            _loading.Hide();
        }
    }
    

[RelayCommand]
private async Task GoogleLoginAsync()
{
    if (IsAuthInProgress)
        return;

    // Проверка согласия на обработку ПД (может создать новый аккаунт)
    if (!IsDataProcessingAccepted)
    {
        ShowInlineError("Необходимо дать согласие на обработку персональных данных");
        return;
    }

    IsAuthInProgress = true;

    // id попытки (чтобы игнорировать "долетающие" результаты)
    var attemptId = Interlocked.Increment(ref _googleAttemptId);

    // отменяем предыдущую попытку на уровне UI
    _googleUiCts?.Cancel();
    _googleUiCts?.Dispose();
    _googleUiCts = new CancellationTokenSource();

    var uiCt = _googleUiCts.Token;

    try
    {
        _loading.Show();
        IsErrorVisible = false;

        var authTask = GoogleOAuthTest.GetAuthCodeAsync();
        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(60), uiCt);

        var completed = await Task.WhenAny(authTask, timeoutTask);

        // если пришла новая попытка — просто выходим
        if (attemptId != _googleAttemptId)
            return;

        // таймаут или явная отмена UI
        if (completed != authTask || uiCt.IsCancellationRequested)
        {
            if (_loading.IsShown)
                _loading.Hide();

            await Task.Delay(50);
            await Shell.Current.DisplayAlert("Google", "Авторизация отменена или не завершена.", "OK");
            return;
        }

        // authTask завершился
        var code = await authTask;

        if (attemptId != _googleAttemptId)
            return;

        if (string.IsNullOrWhiteSpace(code))
            return;

        var tokens = await GoogleOAuthTest.ExchangeCodeAsync(code);
        var payload = GoogleOAuthTest.ParseIdToken(tokens.IdToken);

        var email = payload.email;
        var sub = payload.sub;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sub))
            throw new Exception("Google token has no email/sub");

        var user = await _authService.LoginAsync(email, sub);

        if (attemptId != _googleAttemptId)
            return;

        if (user == null)
        {
            if (_loading.IsShown)
                _loading.Hide();

            await Task.Delay(50);

            var popupResult = await Shell.Current.ShowPopupAsync(new ChooseRolePopup());
            var role = popupResult as string;
            if (role is null)
                return;

            _loading.Show();

            var regError = await _authService.RegisterUserAsync(
                login: email,
                password: sub,
                firstName: payload.given_name ?? "Google",
                lastName: payload.family_name ?? "User",
                middleName: "",
                roleName: role);

            if (regError != null)
                throw new Exception(regError);

            user = await _authService.LoginAsync(email, sub);
        }

        if (attemptId != _googleAttemptId)
            return;

        if (user == null)
            throw new Exception("Не удалось войти после регистрации.");

        if (await HandleNotApprovedAsync(user))
        {
            _sessionService.EndSession();
            return;
        }

        await _sessionService.StartSessionAsync(user);
        await NavigateByRoleAsync(user.Role?.Name);
    }
    catch (OperationCanceledException)
    {
        // нормально: отменили UI/таймаут
    }
    catch (Exception ex)
    {
        if (attemptId != _googleAttemptId)
            return;

        await Shell.Current.DisplayAlert("Google login error", ex.Message, "OK");
    }
    finally
    {
        // закрываем лоадер только для актуальной попытки
        if (attemptId == _googleAttemptId && _loading.IsShown)
            _loading.Hide();

        IsAuthInProgress = false;
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

    [RelayCommand]
    private async Task ShowPrivacyPolicyAsync()
    {
        await Shell.Current.ShowPopupAsync(new PrivacyPolicyPopup());
    }
    
    public void CancelGoogleAuthUiFromPage()
    {
        // отменяем "ожидание" в GoogleLoginAsync (если ты завязал Delay на этот токен)
        _googleUiCts?.Cancel();

        // и гарантированно закрываем popup-лоадер
        _loading.Hide();

        IsAuthInProgress = false;
    }
    
}
