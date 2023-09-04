namespace BidConReport.Client.Shared.EstimationProcessing.Models;
public class Group : ISheetItem
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
    public double? TotalCost => Children?.Sum(x => x.TotalCost);
    public double? UnitAskingPrice => null;
    public double? TotalAskingPrice => Children?.Sum(x => x.TotalAskingPrice);
    public override string ToString()
    {
        return $"{Description}";
    }
}
