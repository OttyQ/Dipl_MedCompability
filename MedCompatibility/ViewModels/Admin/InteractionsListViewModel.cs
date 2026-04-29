using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedCompatibility.Models;
using MedCompatibility.Pages.Admin;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.ViewModels.Admin;

public partial class InteractionsListViewModel : ObservableObject
{
    private readonly IInteractionService _interactionService;

    [ObservableProperty]
    private ObservableCollection<interaction> interactions = new();

    [ObservableProperty]
    private ObservableCollection<risklevel> riskLevels = new();

    [ObservableProperty]
    private risklevel selectedRiskLevel;

    [ObservableProperty]
    private ObservableCollection<interactiontype> interactionTypes = new();

    [ObservableProperty]
    private interactiontype selectedInteractionType;

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    private bool isBusy;

    public InteractionsListViewModel(IInteractionService interactionService)
    {
        _interactionService = interactionService;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            // Инициализация фильтров при первой загрузке
            if (RiskLevels.Count == 0)
            {
                var risks = await _interactionService.GetRiskLevelsAsync();
                risks.Insert(0, new risklevel { RiskLevelId = 0, Name = "Все" });
                RiskLevels = new ObservableCollection<risklevel>(risks);
                SelectedRiskLevel = RiskLevels[0];
            }

            if (InteractionTypes.Count == 0)
            {
                var types = await _interactionService.GetInteractionTypesAsync();
                types.Insert(0, new interactiontype { InteractionTypeId = 0, Name = "Все" });
                InteractionTypes = new ObservableCollection<interactiontype>(types);
                SelectedInteractionType = InteractionTypes[0];
            }

            var list = await _interactionService.GetInteractionsFilteredAsync(
                SearchText, 
                SelectedRiskLevel?.RiskLevelId == 0 ? null : SelectedRiskLevel?.RiskLevelId, 
                SelectedInteractionType?.InteractionTypeId == 0 ? null : SelectedInteractionType?.InteractionTypeId);
            
            Interactions = new ObservableCollection<interaction>(list);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ResetFiltersAsync()
    {
        SearchText = string.Empty;
        SelectedRiskLevel = RiskLevels.FirstOrDefault(r => r.RiskLevelId == 0);
        SelectedInteractionType = InteractionTypes.FirstOrDefault(t => t.InteractionTypeId == 0);
        await LoadDataAsync();
    }

    [RelayCommand]
    private async Task DeleteInteractionAsync(interaction item)
    {
        if (item == null) return;
        
        bool confirm = await Shell.Current.DisplayAlert("Удаление", 
            $"Удалить взаимодействие {item.SubstanceId1Navigation.Name} + {item.SubstanceId2Navigation.Name}?", 
            "Да", "Нет");

        if (confirm)
        {
            await _interactionService.DeleteInteractionAsync(item.InteractionId);
            await LoadDataAsync();
        }
    }
    
    [RelayCommand]
    private async Task GoToAddInteractionAsync()
    {
        await Shell.Current.GoToAsync(nameof(InteractionAddPage));
    }

    [RelayCommand]
    private async Task EditInteractionAsync(interaction item)
    {
        if (item == null) return;
        var navParam = new Dictionary<string, object>
        {
            { "InteractionToEdit", item }
        };
        await Shell.Current.GoToAsync(nameof(InteractionAddPage), navParam);
    }

    partial void OnSelectedRiskLevelChanged(risklevel value) => LoadDataCommand.Execute(null);
    partial void OnSelectedInteractionTypeChanged(interactiontype value) => LoadDataCommand.Execute(null);
}