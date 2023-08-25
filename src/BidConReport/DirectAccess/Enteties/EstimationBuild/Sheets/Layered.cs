namespace BidConReport.BidconAccess.Enteties.EstimationBuild.Sheets;
public class Layered : ISheetItem
{
    public required string Description { get; set; }
    public ISheetItem? Parent {get; set;}
    public double? Quantity { get; set; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => UnitResourceCosts.Sum(x => x.Value);
    public double? TotalCost => UnitCost * Quantity;
    public Dictionary<int, double?> UnitResourceCosts { get; set; } = new();
    public override string ToString()
    {
        return $"{Description}";
    }
}
