using CommunityToolkit.Maui.Views;
using MedCompatibility.Pages.Shared.Popups;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class LoadingService : ILoadingService
{
    private Popup? _popup;

    public void Show()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (_popup != null)
                return;

            try
            {
                _popup = new LoadingPopup();
                Shell.Current?.ShowPopup(_popup);
            }
            catch
            {
                _popup = null;
            }
        });
    }

    public void Hide()
    {
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

            }
        });
    }
    
    public bool IsShown => _popup != null;
}