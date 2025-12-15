using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class ConfirmPopup : Popup
{
    public ConfirmPopup(string title, string message, string okText = "OK", string cancelText = "Отмена")
    {
        InitializeComponent();
        BindingContext = new Vm(title, message, okText, cancelText);
    }

    private void OnOkClicked(object sender, EventArgs e) => Close(true);
    private void OnCancelClicked(object sender, EventArgs e) => Close(false);

    private partial class Vm : ObservableObject
    {
        public Vm(string title, string message, string okText, string cancelText)
        {
            TitleText = title;
            MessageText = message;
            OkText = okText;
            CancelText = cancelText;
        }

        public string TitleText { get; }
        public string MessageText { get; }
        public string OkText { get; }
        public string CancelText { get; }
    }
}