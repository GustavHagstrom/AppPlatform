namespace BidConReport.BidconDatabaseAccess.Enteties.EstimationBuild.Sheets;
public class Text : ISheetItem
{
    public required string Description { get; set; }
    public ISheetItem? Parent {get; set;}
    public double? Quantity
    {
        get { return null; }
        set { /* Do nothing */ }
    }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit => null;
    public double? UnitCost => null;
    public double? TotalCost => UnitCost * Quantity;
}
