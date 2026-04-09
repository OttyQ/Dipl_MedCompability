using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace MedCompatibility.Pages.Shared.Controls;

public partial class CustomHeader : ContentView
{
    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title), typeof(string), typeof(CustomHeader), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    // Свойство для правого контента (кнопки)
    public static readonly BindableProperty RightContentProperty =
        BindableProperty.Create(nameof(RightContent), typeof(View), typeof(CustomHeader), null);

    public View RightContent
    {
        get => (View)GetValue(RightContentProperty);
        set => SetValue(RightContentProperty, value);
    }

    // Свойство для скрытия кнопки "Назад" (на главных страницах она не нужна)
    public static readonly BindableProperty IsBackButtonVisibleProperty =
        BindableProperty.Create(nameof(IsBackButtonVisible), typeof(bool), typeof(CustomHeader), true);

    public bool IsBackButtonVisible
    {
        get => (bool)GetValue(IsBackButtonVisibleProperty);
        set => SetValue(IsBackButtonVisibleProperty, value);
    }

    public CustomHeader()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        if (sender is View view)
        {
            await view.ScaleTo(0.85, 100, Easing.CubicOut);
            await view.ScaleTo(1.0, 100, Easing.CubicIn);
        }
        await Shell.Current.GoToAsync("..");
    }
}