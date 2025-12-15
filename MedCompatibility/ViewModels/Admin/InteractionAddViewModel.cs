using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using MedCompatibility.Pages.Shared.Popups;

namespace MedCompatibility.ViewModels.Admin;

public partial class InteractionAddViewModel : ObservableObject, IQueryAttributable
{
    private readonly IInteractionService _interactionService;
    private readonly IMedicineService _medicineService;
    
    // Задача загрузки справочников, чтобы мы могли её ждать
    private Task _initializationTask; 

    [ObservableProperty]
    private interaction currentInteraction = new();

    // Справочники
    [ObservableProperty]
    private ObservableCollection<interactiontype> types = new();
    
    [ObservableProperty]
    private ObservableCollection<risklevel> risks = new();

    // Выбранные значения
    [ObservableProperty]
    private interactiontype selectedType;

    [ObservableProperty]
    private risklevel selectedRisk;

    [ObservableProperty]
    private activesubstance substance1;

    [ObservableProperty]
    private activesubstance substance2;

    [ObservableProperty]
    private string pageTitle = "Создание конфликта";
    
    [ObservableProperty]
    private string buttonText = "Создать";

    public InteractionAddViewModel(IInteractionService interactionService, IMedicineService medicineService)
    {
        _interactionService = interactionService;
        _medicineService = medicineService;
        
        // Запускаем загрузку сразу, но сохраняем Task
        _initializationTask = LoadDictionariesAsync();
    }

    // Изменили void на Task
    private async Task LoadDictionariesAsync()
    {
        try
        {
            // Если уже загружено - не грузим повторно
            if (Types.Any() && Risks.Any()) return;

            var t = await _interactionService.GetInteractionTypesAsync();
            var r = await _interactionService.GetRiskLevelsAsync();

            // Обновляем UI в главном потоке
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Types = new ObservableCollection<interactiontype>(t);
                Risks = new ObservableCollection<risklevel>(r);
            });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка загрузки", ex.Message, "OK");
        }
    }

    [RelayCommand]
    private async Task SelectSubstance1Async()
    {
        var popup = new SelectSubstancePopup(_medicineService);
        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is activesubstance sub) Substance1 = sub;
    }

    [RelayCommand]
    private async Task SelectSubstance2Async()
    {
        var popup = new SelectSubstancePopup(_medicineService);
        var result = await Shell.Current.ShowPopupAsync(popup);
        if (result is activesubstance sub) Substance2 = sub;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (Substance1 == null || Substance2 == null || SelectedType == null || SelectedRisk == null)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Заполните все обязательные поля", "OK");
            return;
        }

        if (Substance1.SubstanceId == Substance2.SubstanceId)
        {
            await Shell.Current.DisplayAlert("Ошибка", "Вещества должны быть разными", "OK");
            return;
        }

        try
        {
            CurrentInteraction.SubstanceId1 = Substance1.SubstanceId;
            CurrentInteraction.SubstanceId2 = Substance2.SubstanceId;
            CurrentInteraction.InteractionTypeId = SelectedType.InteractionTypeId;
            CurrentInteraction.RiskLevelId = SelectedRisk.RiskLevelId;

            if (CurrentInteraction.InteractionId == 0)
            {
                await _interactionService.AddInteractionAsync(
                    CurrentInteraction.SubstanceId1,
                    CurrentInteraction.SubstanceId2,
                    CurrentInteraction.InteractionTypeId,
                    CurrentInteraction.RiskLevelId,
                    CurrentInteraction.Description,
                    CurrentInteraction.Recommendation);
                
                await Shell.Current.DisplayAlert("Успех", "Взаимодействие создано", "OK");
            }
            else
            {
                await _interactionService.UpdateInteractionAsync(CurrentInteraction);
                await Shell.Current.DisplayAlert("Успех", "Изменения сохранены", "OK");
            }

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("InteractionToEdit"))
        {
            var source = query["InteractionToEdit"] as interaction;
            if (source != null)
            {
                await LoadForEdit(source.InteractionId);
            }
        }
    }

    private async Task LoadForEdit(int id)
    {
        // 1. Сначала ждем окончания загрузки справочников!
        await _initializationTask;

        var item = await _interactionService.GetInteractionByIdAsync(id);
        if (item == null) return;

        CurrentInteraction = item;

        Substance1 = item.SubstanceId1Navigation;
        Substance2 = item.SubstanceId2Navigation;

        // 2. Теперь списки точно заполнены, и поиск сработает
        SelectedType = Types.FirstOrDefault(t => t.InteractionTypeId == item.InteractionTypeId);
        SelectedRisk = Risks.FirstOrDefault(r => r.RiskLevelId == item.RiskLevelId);

        PageTitle = "Редактирование";
        ButtonText = "Сохранить изменения";
    }
}
