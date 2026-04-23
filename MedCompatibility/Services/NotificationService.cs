using Plugin.LocalNotification;
using MedCompatibility.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MedCompatibility.Services;

public class NotificationService : MedCompatibility.Services.Interfaces.INotificationService
{
    private async Task<bool> CheckAndRequestPermissions()
    {
        if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
        {
            return await LocalNotificationCenter.Current.RequestNotificationPermission();
        }
        return true;
    }

    public async Task ScheduleDailyRemindersAsync()
    {
        if (!await CheckAndRequestPermissions()) return;

        LocalNotificationCenter.Current.CancelAll(); // Сброс старых

        var morningReq = new NotificationRequest
        {
            NotificationId = 101,
            Title = "MedCompatibility",
            Description = "Напоминание: проверьте график приёма лекарств на утро",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Today.Add(new TimeSpan(9, 0, 0)),
                RepeatType = NotificationRepeat.Daily
            }
        };

        var eveningReq = new NotificationRequest
        {
            NotificationId = 102,
            Title = "MedCompatibility",
            Description = "Напоминание: проверьте график приёма лекарств на вечер",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Today.Add(new TimeSpan(21, 0, 0)),
                RepeatType = NotificationRepeat.Daily
            }
        };

        await LocalNotificationCenter.Current.Show(morningReq);
        await LocalNotificationCenter.Current.Show(eveningReq);
    }

    public Task CancelAllRemindersAsync()
    {
        LocalNotificationCenter.Current.CancelAll();
        return Task.CompletedTask;
    }

    public async Task SendTestNotificationAsync()
    {
        if (!await CheckAndRequestPermissions()) return;

        var testReq = new NotificationRequest
        {
            NotificationId = 999,
            Title = "Тестовое уведомление",
            Description = "Уведомления MedCompatibility работают корректно!",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(5) // Сработает через 5 секунд
            }
        };
        await LocalNotificationCenter.Current.Show(testReq);
    }
}
