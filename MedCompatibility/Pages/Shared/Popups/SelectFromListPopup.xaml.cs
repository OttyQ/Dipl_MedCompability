using CommunityToolkit.Maui.Views;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class SelectFromListPopup : Popup
{
    private readonly List<ItemVm> _all;

    public SelectFromListPopup(string title, IEnumerable<object> items, Func<object, string> display)
    {
        InitializeComponent();

        _all = items
            .Select(i => new ItemVm(i, display(i)))
            .ToList();

        BindingContext = new Vm
        {
            Title = title,
            Items = new List<ItemVm>(_all)
        };

        ResultsList.ItemsSource = ((Vm)BindingContext).Items;
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var vm = (Vm)BindingContext;
        vm.SearchText = e.NewTextValue ?? string.Empty;

        var q = vm.SearchText.Trim();
        var filtered = string.IsNullOrWhiteSpace(q)
            ? _all
            : _all.Where(x => x.Display.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();

        vm.Items = filtered;
        ResultsList.ItemsSource = vm.Items;
    }

    private void OnClearSearchClicked(object sender, EventArgs e)
    {
        SearchEntry.Text = string.Empty;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is ItemVm selected)
            Close(selected.Value);
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);

    private sealed class Vm
    {
        public string Title { get; set; } = "";
        public string SearchText { get; set; } = "";
        public List<ItemVm> Items { get; set; } = new();
    }

    private sealed class ItemVm
    {
        public ItemVm(object value, string display)
        {
            Value = value;
            Display = display;
        }

        public object Value { get; }
        public string Display { get; }
    }
}