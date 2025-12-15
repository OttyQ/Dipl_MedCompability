using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class DbUnavailablePopup : Popup
{
    public DbUnavailablePopup(string shortMessage, string details)
    {
        InitializeComponent();
        BindingContext = new Vm(this, shortMessage, details);
    }

    private sealed class Vm
    {
        private readonly Popup _popup;

        public string ShortMessage { get; }
        public string Details { get; }

        public Command CloseCommand => new(() => _popup.Close());
        public Command CopyCommand => new(async () => await Clipboard.SetTextAsync(Details));

        public Vm(Popup popup, string shortMessage, string details)
        {
            _popup = popup;
            ShortMessage = shortMessage;
            Details = details;
        }
    }
}