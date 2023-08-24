using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;
public class GroupCalculator : ISheetItemCostCalculator
{
    private readonly PartCalculator _partCalculator = new();
    public Dictionary<int, double?> CalculateTotalCosts(SheetItem item, EstimationBatch batch)
    {
        Dictionary<int, double?> costs = new();
        foreach (var child in item.SheetItems)
        {
            var calculatedCosts = _partCalculator.CalculateTotalCosts(child, batch);
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

    public Dictionary<int, double?> CalculateUnitCosts(SheetItem item, EstimationBatch batch)
    {
        return new Dictionary<int, double?>();
    }
}
