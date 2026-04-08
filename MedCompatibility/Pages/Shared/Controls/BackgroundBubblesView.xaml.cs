using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MedCompatibility.Pages.Shared.Controls;

public partial class BackgroundBubblesView : ContentView
{
    // Параметры для верхнего бирюзового пятна
    public static readonly BindableProperty TopBubbleBoundsProperty =
        BindableProperty.Create(nameof(TopBubbleBounds), typeof(Rect), typeof(BackgroundBubblesView), new Rect(0.15, 0.08, 420, 420));

    public Rect TopBubbleBounds
    {
        get => (Rect)GetValue(TopBubbleBoundsProperty);
        set => SetValue(TopBubbleBoundsProperty, value);
    }

    // Параметры для правого голубого пятна
    public static readonly BindableProperty RightBubbleBoundsProperty =
        BindableProperty.Create(nameof(RightBubbleBounds), typeof(Rect), typeof(BackgroundBubblesView), new Rect(0.95, 0.30, 520, 520));

    public Rect RightBubbleBounds
    {
        get => (Rect)GetValue(RightBubbleBoundsProperty);
        set => SetValue(RightBubbleBoundsProperty, value);
    }

    // Параметры для нижнего нейтрального пятна
    public static readonly BindableProperty BottomBubbleBoundsProperty =
        BindableProperty.Create(nameof(BottomBubbleBounds), typeof(Rect), typeof(BackgroundBubblesView), new Rect(0.35, 0.98, 620, 620));

    public Rect BottomBubbleBounds
    {
        get => (Rect)GetValue(BottomBubbleBoundsProperty);
        set => SetValue(BottomBubbleBoundsProperty, value);
    }

    public BackgroundBubblesView()
    {
        InitializeComponent();
    }
}