using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class LoadingService : ILoadingService
{
    private Popup? _popup;

    public void Show()
    {
        // Если уже показан — не плодим новые
        if (_popup != null) return;

        // Важно вызывать в главном потоке, т.к. работаем с UI
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _popup = new LoadingPopup();
            Shell.Current.ShowPopup(_popup);
        });
    }

    public void Hide()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            try
            {
                _popup?.Close();
            }
            catch
            {
                // Игнорируем ошибки закрытия (если уже закрыт)
            }
            finally
            {
                _popup = null;
            }
        });
    }
}