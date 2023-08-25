namespace BidConReport.BidconAccess.Enteties.EstimationBuild.Sheets;
public class Layered : ISheetItem
{
    private double? _quantity;

    public required string Description { get; set; }
    public ISheetItem? Parent {get; set;}
    public double? Quantity { get => _quantity * (Parent is null || Parent is not Part ? 1 : Parent.Quantity); set => _quantity = value; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => ResourceUnitCosts.Sum(x => x.Value * ATAResourceFactor(x.Key));//ResourceUnitCosts.Select(x => ATA is null ? x.Value : ATA.AdditionalFactors[x.Key] * x.Value).Sum();
    public double? TotalCost => UnitCost * Quantity;
    public Dictionary<int, double?> ResourceUnitCosts { get; set; } = new();
    public ATA? ATA { get; set; }
    private double ATAResourceFactor(int resourceType)
    {
        if (ATA is null || Quantity is null)
        {
            return 1;
        }
        if (Quantity < 0)
        {
            return ATA.RemovalFactors[resourceType];
        }
        else
        {
            return ATA.AdditionalFactors[resourceType];
        }
    }
    public override string ToString()
    {
        return $"{Description}";
    }
}
