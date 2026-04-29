using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class ChangePasswordPopup : Popup
{
    public ChangePasswordPopup()
    {
        InitializeComponent();
    }

    private void OnToggleOldPasswordClicked(object sender, EventArgs e) => TogglePassword(OldPasswordEntry, ToggleOldPasswordBtn);
    private void OnToggleNewPasswordClicked(object sender, EventArgs e) => TogglePassword(NewPasswordEntry, ToggleNewPasswordBtn);
    private void OnToggleConfirmPasswordClicked(object sender, EventArgs e) => TogglePassword(ConfirmPasswordEntry, ToggleConfirmPasswordBtn);

    private void TogglePassword(Entry entry, Button button)
    {
        entry.IsPassword = !entry.IsPassword;
        button.Text = entry.IsPassword ? "🙈" : "🙉";
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Close(null);
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;

        string oldPass = OldPasswordEntry.Text;
        string newPass = NewPasswordEntry.Text;
        string confirmPass = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(oldPass) || 
            string.IsNullOrWhiteSpace(newPass) || 
            string.IsNullOrWhiteSpace(confirmPass))
        {
            ErrorLabel.Text = "Заполните все поля";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (newPass != confirmPass)
        {
            ErrorLabel.Text = "Новые пароли не совпадают";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (newPass.Length < 6)
        {
            ErrorLabel.Text = "Пароль должен содержать минимум 6 символов";
            ErrorLabel.IsVisible = true;
            return;
        }

        Close((OldPassword: oldPass, NewPassword: newPass));
    }
}
