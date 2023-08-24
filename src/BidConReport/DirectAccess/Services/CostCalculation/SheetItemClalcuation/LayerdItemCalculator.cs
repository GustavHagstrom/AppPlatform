using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enums;
using BidConReport.BidconDatabaseAccess.Services.CostCalculation.LayerCalculation;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;
public class LayerdItemCalculator : ISheetItemCostCalculator
{
    private readonly Dictionary<int, ILayerCostCalculator> _calculatorMap = new()
    {
        { (int)LayerType.WorkResult, new WRLayerCalculator() },
        { (int)LayerType.DesignElement, new DELayerCalculator() },
        { (int)LayerType.MixedElement, new MELayerCalculator() },
    };

    public Dictionary<int, double?> CalculateTotalCosts(SheetItem item, EstimationBatch batch)
    {
        Dictionary<int, double?> totalCosts = new();
        foreach (var cost in CalculateUnitCosts(item, batch))
        {
            totalCosts.Add(cost.Key, cost.Value * item.Quantity);
        }
        return totalCosts;
    }

    public Dictionary<int, double?> CalculateUnitCosts(SheetItem item, EstimationBatch batch)
    {
        return _calculatorMap[item.LayerType!.Value].Calculate(batch, item.LayerId);
    }
}
