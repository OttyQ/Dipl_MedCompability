using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class LoadingService : ILoadingService
{
    private Popup? _popup;
    private int _showCount = 0;
    private readonly object _lock = new();

    public void Show()
    {
        lock (_lock)
        {
            _showCount++;
            if (_showCount > 1) return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_popup != null) return;

            try
            {
                _popup = new LoadingPopup();
                // Используем CurrentPage для более надежного отображения
                Shell.Current?.CurrentPage?.ShowPopup(_popup);
            }
            catch
            {
                lock (_lock) { _showCount = 0; }
                _popup = null;
            }
        });
    }

    public void Hide()
    {
        lock (_lock)
        {
            if (_showCount > 0) _showCount--;
            if (_showCount > 0) return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            var p = _popup;
            _popup = null;

            try
            {
                p?.Close();
            }
            catch
            {
                // Игнорируем ошибки при закрытии
            }
        });
    }

    public bool IsShown => _showCount > 0;
}