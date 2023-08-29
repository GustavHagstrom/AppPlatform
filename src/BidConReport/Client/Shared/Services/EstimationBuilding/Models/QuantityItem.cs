﻿namespace BidConReport.Client.Shared.Services.EstimationBuilding.Models;
public class QuantityItem : ISheetItem
{
    public required string Description { get; set; }
    public ISheetItem? Parent { get; set; }
    public double? Quantity { get; set; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => null;
    public double? TotalCost => UnitCost * Quantity;
    public double? UnitAskingPrice => null;
    public double? TotalAskingPrice => null;
    public int? AddedInPhase { get; set; }
    public override string ToString()
    {
        return $"{Description}";
    }
}
