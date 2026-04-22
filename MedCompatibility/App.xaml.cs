using MedCompatibility.Services.Interfaces;

namespace MedCompatibility;

public partial class App : Application
{
    private readonly IUserSessionService _sessionService;
    private readonly ILoadingService _loadingService;

    public App(IUserSessionService sessionService, ILoadingService loadingService)
    {
        InitializeComponent();
        _sessionService = sessionService;
        _loadingService = loadingService;

        MainPage = new AppShell();
    }

    protected override async void OnStart()
    {
        base.OnStart();
        
        await RestoreSessionAsync();
    }

    private async Task RestoreSessionAsync()
    {
        try
        {
            // Проверяем наличие ключа в SecureStorage ПЕРЕД тем как включать лоадер.
            // Это позволит не показывать пустой экран загрузки, если пользователь еще не логинился.
            var userIdStr = await SecureStorage.Default.GetAsync("auth_user_id");
            if (string.IsNullOrEmpty(userIdStr))
                return;

            // Если сессия была, даем Shell секунду на подготовку и показываем лоадер
            await Task.Delay(100);
            _loadingService.Show();

            bool restored = await _sessionService.RestoreSessionAsync();

            if (restored && _sessionService.CurrentUser != null)
            {
                var role = _sessionService.CurrentUser.Role?.Name?.ToLower();
                
                string route = role switch
                {
                    "admin" => "//Admin",
                    "doctor" => "//Doctor",
                    _ => "//Patient"
                };

                await Shell.Current.GoToAsync(route);
            }
        }
        catch (Exception ex)
        {
            // Выводим ошибку пользователю, если что-то пошло не так (например, нет интернета)
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Shell.Current.DisplayAlert("Авторизация", 
                    "Не удалось восстановить сессию. Пожалуйста, проверьте интернет-соединение или войдите вручную.\n\n" + 
                    "Детали: " + ex.Message, "OK");
            });
        }
        finally
        {
            _loadingService.Hide();
        }
    }
}