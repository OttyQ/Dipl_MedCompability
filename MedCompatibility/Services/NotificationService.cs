using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using MedCompatibility.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MedCompatibility.Services;

public class NotificationService : MedCompatibility.Services.Interfaces.INotificationService
{
    private static bool _isInitialized = false;

    private async Task<bool> CheckAndRequestPermissions()
    {
#if ANDROID || IOS
        if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
        {
            return await LocalNotificationCenter.Current.RequestNotificationPermission();
        }
#endif
        return true;
    }

    public async Task ScheduleDailyRemindersAsync()
    {
        try
        {
            if (!await CheckAndRequestPermissions())
                return;

            // На Windows планировщик часто работает некорректно и вызывает немедленные уведомления
            if (DeviceInfo.Current.Platform == DevicePlatform.WinUI && _isInitialized)
                return;

            LocalNotificationCenter.Current.CancelAll();

            DateTime now = DateTime.Now;
            DateTime morningTime = DateTime.Today.AddHours(9);
            DateTime eveningTime = DateTime.Today.AddHours(21);

            if (now >= morningTime) morningTime = morningTime.AddDays(1);
            if (now >= eveningTime) eveningTime = eveningTime.AddDays(1);

            var morningReq = CreateReminderRequest(101, "Утренний приём", morningTime);
            var eveningReq = CreateReminderRequest(102, "Вечерний приём", eveningTime);

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await LocalNotificationCenter.Current.Show(morningReq);
                await LocalNotificationCenter.Current.Show(eveningReq);
                _isInitialized = true;
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[NotificationService] Schedule error: {ex.Message}");
        }
    }

    private NotificationRequest CreateReminderRequest(int id, string subtitle, DateTime notifyTime)
    {
        return new NotificationRequest
        {
            NotificationId = id,
            Title = "MedCompatibility",
            Subtitle = "Напоминание о приёме",
            Description = "Пора проверить график приёма лекарств.",
            CategoryType = NotificationCategoryType.Reminder,
            Android = new AndroidOptions
            {
                IconSmallName = new AndroidIcon("ic_notification"),
                Priority = AndroidPriority.High
                // Цвет отключен, так как вызывает сбои на Android
            },
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = notifyTime,
                RepeatType = NotificationRepeat.Daily
            }
        };
    }

    public async Task CancelAllRemindersAsync()
    {
        LocalNotificationCenter.Current.CancelAll();
        _isInitialized = false;
        await Task.CompletedTask;
    }

    public async Task SendTestNotificationAsync()
    {
        try
        {
            if (!await CheckAndRequestPermissions())
                return;

            // Используем ту же логику, что и в реальных уведомлениях
            var testReq = CreateReminderRequest(999, "ТЕСТ: Напоминание", DateTime.Now.AddSeconds(10));
            testReq.Schedule.RepeatType = NotificationRepeat.No;

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await LocalNotificationCenter.Current.Show(testReq);
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[NotificationService] Test error: {ex.Message}");
        }
    }
}
