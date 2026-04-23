using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class LoadingService : ILoadingService
{
    private Popup? _popup;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public void Show()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_popup != null) return;
            try
            {
                var page = GetTopPage();
                if (page == null) return;
                _popup = new LoadingPopup();
                page.ShowPopup(_popup);
            }
            catch
            {
                _popup = null;
            }
        });
    }

    public void Hide()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            var p = _popup;
            _popup = null;
            if (p == null) return;
            try
            {
                await p.CloseAsync();
            }
            catch
            {
                // игнорируем
            }
        });
    }

    public bool IsShown => _popup != null;

    private static Page? GetTopPage()
    {
        var root = Application.Current?.Windows
            .FirstOrDefault()?.Page;

        if (root is Shell shell)
            return shell.CurrentPage ?? shell;

        return root;
    }
}