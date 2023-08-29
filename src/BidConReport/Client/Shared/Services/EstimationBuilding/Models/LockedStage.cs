namespace BidConReport.Client.Shared.Services.EstimationBuilding.Models;
public class LockedStage : ISheetItem
{
    public required string Description { get; set; }
    public ISheetItem? Parent { get; set; }
    public double? Quantity
    {
        get { return null; }
        set { /* Do nothing */ }
    }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit => null;
    public double? UnitCost => null;
    public double? TotalCost => null;
    public double? UnitAskingPrice => null;
    public double? TotalAskingPrice => null;
    public int? AddedInPhase { get; set; }
    public override string ToString()
    {
        return $"{Description}";
    }
}
