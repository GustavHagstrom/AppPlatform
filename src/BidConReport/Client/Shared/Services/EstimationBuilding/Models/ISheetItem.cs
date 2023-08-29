﻿namespace BidConReport.Client.Shared.Services.EstimationBuilding.Models;

public interface ISheetItem
{
    string Description { get; set; }
    ISheetItem? Parent { get; }
    double? Quantity { get; set; }
    List<ISheetItem> Children { get; }
    string? Unit { get; }
    double? UnitCost { get; }
    double? TotalCost { get; }
    double? UnitAskingPrice { get; }
    double? TotalAskingPrice { get; }
    int? AddedInPhase { get; }
    public IEnumerable<ISheetItem> AllInOrder
    {
        get
        {
            yield return this;
            foreach (var child in Children)
            {
                foreach (var subChild in child.AllInOrder)
                {
                    yield return subChild;
                }
            }
        }
    }
}