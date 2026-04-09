using Microsoft.Maui.Controls;

namespace MedCompatibility.Helpers
{
    public static class DesktopLayout
    {
        public static readonly BindableProperty ForceWidthProperty =
            BindableProperty.CreateAttached("ForceWidth", typeof(double), typeof(DesktopLayout), -1.0, propertyChanged: OnForceWidthChanged);

        public static double GetForceWidth(BindableObject view) => (double)view.GetValue(ForceWidthProperty);
        public static void SetForceWidth(BindableObject view, double value) => view.SetValue(ForceWidthProperty, value);

        private static void OnForceWidthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is VisualElement view && newValue is double width && width > 0)
            {
#if WINDOWS || MACCATALYST
                view.WidthRequest = width;
#endif
            }
        }
    }
}
