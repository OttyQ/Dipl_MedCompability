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
            var userIdStr = await SecureStorage.Default.GetAsync("auth_user_id");
            if (string.IsNullOrEmpty(userIdStr)) return;

            // Никаких лоадеров! Просто запрашиваем базу в фоне.
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

                // Делаем мгновенный переход
                await MainThread.InvokeOnMainThreadAsync(async () => 
                {
                    await Shell.Current.GoToAsync(route);
                });
            }
        }
        catch (Exception)
        {
            // Если нет интернета — просто ничего не делаем, 
            // пользователь останется на странице логина и введет данные сам (и там уже сработает обычная обработка ошибок).
            // Убираем DisplayAlert отсюда, чтобы не блокировать UI на старте.
            _sessionService.EndSession(); // На всякий случай чистим мусор
        }
    }
}