namespace BidConReport.BidconDatabaseAccess.Enteties.EstimationBuild.Sheets;
public class Part : ISheetItem
{
    public required string Description { get; set; }
    public ISheetItem? Parent {get; set;}
    public double? Quantity { get; set; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => Children?.Sum(x => x.TotalCost);
    public double? TotalCost => UnitCost * Quantity;
    public override string ToString()
    {
        return $"{Description}";
    }
}
