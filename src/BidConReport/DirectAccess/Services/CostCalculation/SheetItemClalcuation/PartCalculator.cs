using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;
public class PartCalculator : ISheetItemCostCalculator
{
    private readonly LayerdItemCalculator _layerdItemCalculator = new();
    public Dictionary<int, double?> CalculateTotalCosts(SheetItem item, EstimationBatch batch)
    {
        Dictionary<int, double?> costs = new();
        foreach (var cost in CalculateUnitCosts(item, batch))
        {
            costs.Add(cost.Key, cost.Value * item.Quantity);
        }
        return costs;
    }

    public Dictionary<int, double?> CalculateUnitCosts(SheetItem item, EstimationBatch batch)
    {
        Dictionary<int, double?> costs = new();
        foreach (var child in item.SheetItems)
        {
            var calculatedCosts = _layerdItemCalculator.CalculateTotalCosts(child, batch);
            foreach (var cost in calculatedCosts)
            {
                if (costs.ContainsKey(cost.Key))
                {
                    costs[cost.Key] += cost.Value;
                }
                else
                {
                    costs[cost.Key] = cost.Value;
                }
            }
        }
        return costs;
    }
}
