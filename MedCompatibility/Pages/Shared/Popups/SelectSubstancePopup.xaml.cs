using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using System.Collections.ObjectModel;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class SelectSubstancePopup : Popup
{
    private readonly IMedicineService _service;
    private List<activesubstance> _allCachedSubstances = new(); // Кеш всех веществ

    public SelectSubstancePopup(IMedicineService service)
    {
        InitializeComponent();
        _service = service;
        
        // Запускаем загрузку
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        try
        {
            LoadingIndicator.IsVisible = true;
            ResultsList.IsVisible = false;
            CreateBlock.IsVisible = false;

            // Грузим ВСЕ вещества сразу при открытии.
            // Передаем null или "" - сервис должен вернуть всё.
            // Если сервис SearchSubstancesAsync("") не возвращает всё, нужно это проверить в MedicineService.cs
            _allCachedSubstances = await _service.SearchSubstancesAsync("") ?? new List<activesubstance>();
            
            // Сразу показываем список
            UpdateList(_allCachedSubstances);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading substances: {ex}");
        }
        finally
        {
            LoadingIndicator.IsVisible = false;
        }
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue?.Trim() ?? "";
        FilterData(query);
    }
    
    private void OnClearSearchClicked(object sender, EventArgs e)
    {
        SearchEntry.Text = string.Empty;
    }

    private void FilterData(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            // Показываем полный список
            UpdateList(_allCachedSubstances);
            CreateBlock.IsVisible = false;
            return;
        }

        // Фильтруем локально (в памяти), так быстрее и надежнее для небольших списков
        var filtered = _allCachedSubstances
            .Where(s => s.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        UpdateList(filtered);

        // Проверяем точное совпадение
        bool exactMatch = filtered.Any(s => s.Name.Equals(query, StringComparison.OrdinalIgnoreCase));

        // Показываем блок создания, если нет точного совпадения
        CreateBlock.IsVisible = !exactMatch;
        
        if (!exactMatch)
        {
            NewNameEntry.Text = query; 
        }
    }

    private void UpdateList(List<activesubstance> items)
    {
        ResultsList.ItemsSource = items;
        // Показываем список, только если в нем что-то есть
        ResultsList.IsVisible = items.Count > 0;
    }

    private void OnSubstanceSelected(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection.FirstOrDefault() as activesubstance;
        if (selected != null)
        {
            Close(selected);
        }
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NewNameEntry.Text)) return;

        try
        {
            var newSub = await _service.CreateSubstanceAsync(NewNameEntry.Text, NewDescEntry.Text);
            
            // Обновляем кеш, чтобы при следующем открытии оно там было (хотя Popup пересоздается)
            _allCachedSubstances.Add(newSub); 
            
            Close(newSub);
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);
}
