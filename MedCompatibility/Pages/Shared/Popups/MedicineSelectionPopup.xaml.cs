using CommunityToolkit.Maui.Views;
using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.Maui.Controls;

namespace MedCompatibility.Pages.Shared.Popups;

public partial class MedicineSelectionPopup : Popup
{
    private readonly IMedicineService _medicineService;
    private readonly IScanService _scanService;

    // Результат, который вернем: 
    // Либо объект medicine (если выбрали), 
    // Либо string "SCAN" (если нажали сканер)
    public MedicineSelectionPopup(IMedicineService medicineService, IScanService scanService)
    {
        InitializeComponent();
        _medicineService = medicineService;
        _scanService = scanService;
    }

    private void OnScanClicked(object sender, EventArgs e)
    {
        Close("SCAN"); // Возвращаем спец-сигнал, что нужно открыть сканер
    }

    private async void OnHistoryClicked(object sender, EventArgs e)
    {
        SearchLoader.IsRunning = true;
        try
        {
            var history = await _scanService.GetUserHistoryAsync();
            var uniqueMeds = history.Select(h => h.Medicine).DistinctBy(m => m.MedicineId).ToList();
            
            if (!uniqueMeds.Any())
            {
                 // Если истории нет - просто покажем пустоту или алерт (но в попапе алерт сложно)
                 MedicinesList.ItemsSource = new List<medicine>();
            }
            else
            {
                MedicinesList.ItemsSource = uniqueMeds;
            }
        }
        finally
        {
            SearchLoader.IsRunning = false;
        }
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var query = e.NewTextValue;
        if (string.IsNullOrWhiteSpace(query) || query.Length < 2) 
        {
            MedicinesList.ItemsSource = null;
            return;
        }

        SearchLoader.IsRunning = true;
        try
        {
            // Небольшая задержка (debounce), чтобы не бомбить базу на каждой букве
            await Task.Delay(300); 
            if (SearchEntry.Text != query) return; // Если текст уже изменился, отменяем старый запрос

            var results = await _medicineService.SearchMedicinesAsync(query);
            MedicinesList.ItemsSource = results;
        }
        catch
        {
            // Игнорируем ошибки поиска
        }
        finally
        {
            SearchLoader.IsRunning = false;
        }
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is medicine selected)
        {
            Close(selected); // Возвращаем выбранное лекарство
        }
    }
}
