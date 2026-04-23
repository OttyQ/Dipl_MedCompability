namespace MedCompatibility.Services.Interfaces;

public interface INotificationService
{
    Task ScheduleDailyRemindersAsync();
    Task CancelAllRemindersAsync();
    Task SendTestNotificationAsync();
}
