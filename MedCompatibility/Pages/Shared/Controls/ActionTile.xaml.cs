using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MedCompatibility.Pages.Shared.Controls;

public partial class ActionTile : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ActionTile), string.Empty);
    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }

    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string), typeof(ActionTile), string.Empty);
    public string Description { get => (string)GetValue(DescriptionProperty); set => SetValue(DescriptionProperty, value); }

    public static readonly BindableProperty IconTextProperty = BindableProperty.Create(nameof(IconText), typeof(string), typeof(ActionTile), string.Empty);
    public string IconText { get => (string)GetValue(IconTextProperty); set => SetValue(IconTextProperty, value); }

    public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(nameof(IconBackgroundColor), typeof(Color), typeof(ActionTile), Colors.Transparent);
    public Color IconBackgroundColor { get => (Color)GetValue(IconBackgroundColorProperty); set => SetValue(IconBackgroundColorProperty, value); }

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ActionTile), null);
    public ICommand Command { get => (ICommand)GetValue(CommandProperty); set => SetValue(CommandProperty, value); }

    public ActionTile()
    {
        InitializeComponent();
    }

    // Обработчик анимации при клике по плитке
    private async void OnTileTapped(object sender, TappedEventArgs e)
    {
        if (sender is View view)
        {
            // Плавное сжатие "вглубь" и возврат обратно
            await view.ScaleTo(0.95, 100, Easing.CubicOut);
            await view.ScaleTo(1.0, 100, Easing.CubicIn);
        }
    }
}