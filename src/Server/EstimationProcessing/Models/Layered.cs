namespace AppPlatform.Server.EstimationProcessing.Models;
public class Layered : ISheetItem
{
    private double? _quantity;

    public required string Description { get; set; }
    public ISheetItem? Parent { get; set; }
    public int Position { get; set; }
    public double? Quantity { get => _quantity * (Parent is null || Parent is not Part ? 1 : Parent.Quantity); set => _quantity = value; }
    public List<ISheetItem> Children { get; } = new();
    public string? Unit { get; set; }
    public double? UnitCost => ResourceUnitCosts.Sum(x => x.Value * GetATACostFactor(x.Key));
    public double? TotalCost => UnitCost * Quantity;
    public double? UnitAskingPrice => CalculateAskingUnitPrice();
    public double? TotalAskingPrice => UnitAskingPrice * Quantity;
    public Dictionary<int, double?> ResourceUnitCosts { get; set; } = new();
    public required Dictionary<int, double> AskingPriceFactors { get; set; }
    public ATA? ATA { get; set; }
    public int? AddedInPhase { get; set; }
    public required int TenderType { get; set; }
    public double? ManualAskingUnitPrice { get; set; }
    private double? CalculateAskingUnitPrice()
    {
        if (ManualAskingUnitPrice is not null)
        {
            return ManualAskingUnitPrice;
        }
        if (AddedInPhase == (int)AppPlatform.Core.Enums.BidconAccess.EstimationState.Production)
        {
            return ResourceUnitCosts.Sum(x => x.Value * GetATAAskingFactor(x.Key));
        }
        if (TenderType == (int)AppPlatform.Core.Enums.BidconAccess.TenderType.None)
        {
            return null;
        }
        return ResourceUnitCosts.Sum(x => x.Value * AskingPriceFactors[x.Key]);
    }
    private double? GetATAAskingFactor(int resourceType)
    {
        if (ATA is null)
        {
            return null;
        }
        if (Quantity < 0)
        {
            return ATA.RemovalAskingFactors[resourceType] * GetATACostFactor(resourceType);
        }
        else
        {
            return ATA.AdditionalAskingFactors[resourceType] * GetATACostFactor(resourceType);
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
