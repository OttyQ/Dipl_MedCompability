using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Pages.Shared.Popups;

// ─────────────────────────────────────────────────────────────────────────────
// Режимы универсального попапа поиска
// ─────────────────────────────────────────────────────────────────────────────
public enum SearchMode
{
    Лекарство,
    Производитель,
    Вещество
}

// ─────────────────────────────────────────────────────────────────────────────
// Внутренняя ViewModel для строки списка.
// НЕ является моделью БД — создаётся только внутри попапа.
// ─────────────────────────────────────────────────────────────────────────────
internal sealed class SearchItemVm
{
    public required object Original  { get; init; }
    public required string DisplayName { get; init; }
    public string SubText { get; init; } = string.Empty;
}

// ─────────────────────────────────────────────────────────────────────────────
// UniversalSearchPopup
// Единый попап для поиска и (опционально) создания:
//   • Лекарств
//   • Производителей (можно создать новый)
//   • Активных веществ (можно создать новое)
// ─────────────────────────────────────────────────────────────────────────────
public partial class UniversalSearchPopup : Popup
{
    // ── Сервисы ──────────────────────────────────────────────────────────────
    private readonly IMedicineService _medicineService;
    private readonly IScanService?    _scanService;

    // ── Конфигурация ─────────────────────────────────────────────────────────
    private readonly SearchMode _mode;
    private readonly bool       _showAddSection;  // Показывать форму создания
    private readonly bool       _showHistoryTab;  // Показывать вкладку «История»

    // ── Состояние ────────────────────────────────────────────────────────────
    private List<SearchItemVm> _allCached   = new();
    private ObservableCollection<SearchItemVm> _filteredCache = new();

    // ── Свойства для Binding (BindingContext = this) ──────────────────────────
    public string PopupTitle     { get; }
    
    // Показывать ли чип (вместо вкладок)
    public bool   IsHistoryChipVisible => _showHistoryTab && _mode == SearchMode.Лекарство;

    public bool   IsScannerButtonVisible => _mode == SearchMode.Лекарство && 
                                            (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS);

    private bool _isHistoryFilterActive;
    public bool IsHistoryFilterActive
    {
        get => _isHistoryFilterActive;
        set
        {
            if (_isHistoryFilterActive != value)
            {
                _isHistoryFilterActive = value;
                OnPropertyChanged(nameof(IsHistoryFilterActive));
                OnPropertyChanged(nameof(HistoryChipColor));
                OnPropertyChanged(nameof(HistoryChipTextColor));
                ApplyFilter(SearchEntry.Text?.Trim() ?? string.Empty);
            }
        }
    }

    public Color HistoryChipColor => _isHistoryFilterActive ? (Color)Application.Current!.Resources["Primary"] : (Color)Application.Current!.Resources["AppBackground"];
    public Color HistoryChipTextColor => _isHistoryFilterActive ? Colors.White : (Color)Application.Current!.Resources["TextSecondary"];

    private HashSet<int> _historyMedicineIds = new();

    // ─────────────────────────────────────────────────────────────────────────
    // Конструктор
    // ─────────────────────────────────────────────────────────────────────────
    public UniversalSearchPopup(
        IMedicineService medicineService,
        IScanService?    scanService,
        SearchMode       mode,
        bool             showAddSection = false,
        bool             showHistoryTab = false)
    {
        _medicineService = medicineService;
        _scanService     = scanService;
        _mode            = mode;
        _showAddSection  = showAddSection;
        _showHistoryTab  = showHistoryTab;

        InitializeComponent();
        BindingContext = this;

        // Заголовок окна
        PopupTitle = mode switch
        {
            SearchMode.Лекарство     => "Выбор лекарства",
            SearchMode.Производитель => "Выбор производителя",
            SearchMode.Вещество      => "Выбор вещества",
            _                        => "Поиск"
        };

        // Кнопка «Создать» видна только если разрешено добавление
        SaveNewBtn.IsVisible = _showAddSection;

        // Настройка формы создания под режим
        ConfigureCreateBlock();

        // Привязываем ObservableCollection заранее, чтобы ListView знал о нём
        ResultsList.ItemsSource = _filteredCache;

        // Запускаем загрузку данных при фактическом открытии окна, 
        // чтобы гарантировать отрисовку UI и корректное обновление
        this.Opened += (s, e) => LoadInitialDataAsync();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Настройка блока создания под режим (Производитель / Вещество)
    // ─────────────────────────────────────────────────────────────────────────
    private void ConfigureCreateBlock()
    {
        if (_mode == SearchMode.Производитель)
        {
            CreateHintLabel.Text      = "Не найдено. Создать производителя?";
            ManufacturerFields.IsVisible  = true;
            SubstanceDescBorder.IsVisible = false;
        }
        else if (_mode == SearchMode.Вещество)
        {
            CreateHintLabel.Text      = "Не найдено. Создать вещество?";
            ManufacturerFields.IsVisible  = false;
            SubstanceDescBorder.IsVisible = true;
        }
        else
        {
            // Для лекарств создание не поддерживается
            ManufacturerFields.IsVisible  = false;
            SubstanceDescBorder.IsVisible = false;
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Начальная загрузка — выполняется сразу при открытии попапа
    // ─────────────────────────────────────────────────────────────────────────
    private async void LoadInitialDataAsync()
    {
        SetLoading(true);
        try
        {
            if (IsHistoryChipVisible && _scanService != null)
            {
                var historyItems = await FetchHistoryAsync();
                _historyMedicineIds = new HashSet<int>(
                    historyItems.Select(x => ((medicine)x.Original).MedicineId));
            }

            _allCached = await FetchAllAsync();
            ApplyFilter(string.Empty);   // Сразу показываем весь список
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"[UniversalSearchPopup] Ошибка загрузки: {ex}");
        }
        finally
        {
            SetLoading(false);
        }
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Получение данных из сервисов
    // ─────────────────────────────────────────────────────────────────────────
    private Task<List<SearchItemVm>> FetchAllAsync() => _mode switch
    {
        SearchMode.Лекарство     => FetchMedicinesAsync(),
        SearchMode.Производитель => FetchManufacturersAsync(),
        SearchMode.Вещество      => FetchSubstancesAsync(),
        _                        => Task.FromResult(new List<SearchItemVm>())
    };

    private async Task<List<SearchItemVm>> FetchMedicinesAsync()
    {
        var list = await _medicineService.SearchMedicinesAsync(string.Empty) ?? new();
        return list.Select(m => new SearchItemVm
        {
            Original    = m,
            DisplayName = m.TradeName,
            SubText     = m.Manufacturer?.Name ?? string.Empty
        }).ToList();
    }

    private async Task<List<SearchItemVm>> FetchManufacturersAsync()
    {
        var list = await _medicineService.GetAllManufacturersAsync() ?? new();
        return list.Select(m => new SearchItemVm
        {
            Original    = m,
            DisplayName = m.Name,
            SubText     = m.Country ?? string.Empty
        }).ToList();
    }

    private async Task<List<SearchItemVm>> FetchSubstancesAsync()
    {
        var list = await _medicineService.SearchSubstancesAsync(string.Empty) ?? new();
        return list.Select(s => new SearchItemVm
        {
            Original    = s,
            DisplayName = s.Name,
            SubText     = string.Empty
        }).ToList();
    }

    private async Task<List<SearchItemVm>> FetchHistoryAsync()
    {
        if (_scanService == null) return new();

        var history = await _scanService.GetUserHistoryAsync() ?? new();
        return history
            .Select(h => h.Medicine)
            .Where(m => m != null)
            .DistinctBy(m => m.MedicineId)
            .Select(m => new SearchItemVm
            {
                Original    = m,
                DisplayName = m.TradeName,
                SubText     = m.Manufacturer?.Name ?? string.Empty
            })
            .ToList();
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Фильтрация по уже загруженному кешу (без обращения к БД)
    // ─────────────────────────────────────────────────────────────────────────
    private void ApplyFilter(string query)
    {
        var resultList = string.IsNullOrWhiteSpace(query)
            ? _allCached
            : _allCached
                .Where(x => x.DisplayName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

        if (IsHistoryChipVisible && _isHistoryFilterActive)
        {
            resultList = resultList
                .Where(x => x.Original is medicine m && _historyMedicineIds.Contains(m.MedicineId))
                .ToList();
        }

        // Обновляем ObservableCollection
        _filteredCache.Clear();
        foreach (var item in resultList)
        {
            _filteredCache.Add(item);
        }

        ResultsList.IsVisible = true;

        UpdateCreateBlockVisibility(query, resultList.Count);
        UpdateSaveNewBtn();
    }

    // Решает, нужно ли показывать блок создания
    private void UpdateCreateBlockVisibility(string query, int resultCount)
    {
        bool canCreate = _showAddSection
                      && !(_isHistoryFilterActive && IsHistoryChipVisible)
                      && (_mode == SearchMode.Производитель || _mode == SearchMode.Вещество);

        if (!canCreate)
        {
            CreateBlock.IsVisible = false;
            return;
        }

        // Показываем форму только если введён текст и нет точного совпадения
        bool hasExactMatch = _allCached.Any(x =>
            x.DisplayName.Equals(query, StringComparison.OrdinalIgnoreCase));

        bool show = !string.IsNullOrWhiteSpace(query) && !hasExactMatch && resultCount == 0;
        CreateBlock.IsVisible = show;

        if (show && NewNameEntry.Text != query)
            NewNameEntry.Text = query;
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Обработчики поиска
    // ─────────────────────────────────────────────────────────────────────────
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e) =>
        ApplyFilter(e.NewTextValue?.Trim() ?? string.Empty);

    private void OnClearSearchClicked(object sender, EventArgs e) =>
        SearchEntry.Text = string.Empty;

    // ─────────────────────────────────────────────────────────────────────────
    // Обработчик выбора элемента из списка
    // ─────────────────────────────────────────────────────────────────────────
    private void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection?.FirstOrDefault() is SearchItemVm item)
            Close(item.Original);
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Обработчик чипа фильтра истории
    // ─────────────────────────────────────────────────────────────────────────
    private void OnHistoryChipTapped(object sender, EventArgs e)
    {
        IsHistoryFilterActive = !IsHistoryFilterActive;
    }

    // ─────────────────────────────────────────────────────────────────────────
    // Кнопка сканера (Android / iOS only, скрыта через XAML на Windows)
    // ─────────────────────────────────────────────────────────────────────────
    private void OnScanTapped(object sender, EventArgs e) => Close("SCAN");

    // ─────────────────────────────────────────────────────────────────────────
    // Форма создания новой сущности
    // ─────────────────────────────────────────────────────────────────────────
    private void OnCreateNameChanged(object sender, TextChangedEventArgs e) =>
        UpdateSaveNewBtn();

    private void OnCountryPickerChanged(object sender, EventArgs e)
    {
        // Обновляем Label вручную (Picker прозрачен)
        var selected = CountryPicker.SelectedItem?.ToString();
        SelectedCountryLabel.Text      = string.IsNullOrEmpty(selected) ? "Выберите страну" : selected;
        SelectedCountryLabel.TextColor = string.IsNullOrEmpty(selected)
            ? (Color)Application.Current!.Resources["TextSecondary"]
            : (Color)Application.Current!.Resources["TextPrimary"];
    }

    private void UpdateSaveNewBtn()
    {
        bool canSave = _showAddSection
                    && CreateBlock.IsVisible
                    && !string.IsNullOrWhiteSpace(NewNameEntry.Text);

        SaveNewBtn.IsEnabled = canSave;
        SaveNewBtn.Opacity   = canSave ? 1.0 : 0.5;
    }

    private async void OnSaveNewClicked(object sender, EventArgs e)
    {
        var name = NewNameEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(name)) return;

        SaveNewBtn.IsEnabled = false;
        try
        {
            if (_mode == SearchMode.Производитель)
            {
                var country = CountryPicker.SelectedItem?.ToString();
                var city    = NewCityEntry.Text?.Trim();

                var newMan = await _medicineService.CreateManufacturerAsync(
                    name, country, city, description: null);
                Close(newMan);
            }
            else if (_mode == SearchMode.Вещество)
            {
                var desc = NewDescEntry.Text?.Trim();

                var newSub = await _medicineService.CreateSubstanceAsync(name, desc);
                Close(newSub);
            }
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("Ошибка", ex.Message, "OK");
            SaveNewBtn.IsEnabled = true;
        }
    }

    private void OnCancelClicked(object sender, EventArgs e) => Close(null);

    // ─────────────────────────────────────────────────────────────────────────
    // Вспомогательные
    // ─────────────────────────────────────────────────────────────────────────
    private void SetLoading(bool loading)
    {
        LoadingIndicator.IsRunning = loading;
        LoadingIndicator.IsVisible = loading;
        if (loading) ResultsList.IsVisible = false;
    }
}
