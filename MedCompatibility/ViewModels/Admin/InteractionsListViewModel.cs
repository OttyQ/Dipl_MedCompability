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
            var list = await _interactionService.GetAllInteractionsAsync();
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

    // Команда перехода на создание (пока просто заглушка, сделаем попап позже)
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
}