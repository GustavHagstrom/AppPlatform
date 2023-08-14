﻿using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Features.Import.Models;
public class SelectableDbEstimation : DbEstimationDTO
{
    private bool _isSelected;


    public SelectableDbEstimation(DbEstimationDTO dbEstimation, bool isSelected = false)
    {
        this.Id = dbEstimation.Id;
        this.Name = dbEstimation.Name;
        this.Description = dbEstimation.Description;
        _isSelected = isSelected;
    }
    public bool IsSelected
    {
        get => _isSelected; set
        {
            _isSelected = value;
            NotifySelectionChanged();
        }
    }
    public void SetIsSelectedWithoutNotification(bool value)
    {
        _isSelected = value;
    }
    public event Action? SelectionChanged;
    private void NotifySelectionChanged()
    {
        SelectionChanged?.Invoke();
    }
}
