namespace BidConReport.Client.Shared.Services.EstimationBuilding.Models;
public class Layered : ISheetItem
{
    private double? _quantity;

    public required string Description { get; set; }
    public ISheetItem? Parent { get; set; }
    public double? Quantity { get => _quantity * (Parent is null || Parent is not Part ? 1 : Parent.Quantity); set => _quantity = value; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => ResourceUnitCosts.Sum(x => x.Value * GetATACostFactor(x.Key));
    public double? TotalCost => UnitCost * Quantity;
    public double? UnitAskingPrice => ResourceUnitCosts.Sum(x => x.Value * AskingPriceFactors[x.Key] * GetATACostFactor(x.Key) * GetATAAskingFactor(x.Key)); //IF added in production, remove AskingPriceFactors. 
    public double? TotalAskingPrice => UnitAskingPrice * Quantity;
    public Dictionary<int, double?> ResourceUnitCosts { get; set; } = new();
    public required Dictionary<int, double> AskingPriceFactors { get; set; }
    public ATA? ATA { get; set; }
    private double GetATAAskingFactor(int resourceType)
    {
        if (ATA is null)
        {
            return 1;
        }
        if (Quantity < 0)
        {
            return ATA.RemovalAskingFactors[resourceType];
        }
        else
        {
            return ATA.AdditionalAskingFactors[resourceType];
        }
    }
    private double GetATACostFactor(int resourceType)
    {
        if (ATA is null)
        {
            return 1;
        }
        if (Quantity < 0)
        {
            return ATA.RemovalExpenseFactors[resourceType];
        }
        else
        {
            return ATA.AdditionalExpenseFactors[resourceType];
        }
    }
    public override string ToString()
    {
        return $"{Description}";
    }
}
