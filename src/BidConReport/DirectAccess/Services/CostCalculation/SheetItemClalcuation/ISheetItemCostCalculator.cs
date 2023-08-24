using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enteties;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;
public interface ISheetItemCostCalculator
{
    /// <summary>
    /// Diactionare int as ResourceType, double as UnitResourceCost
    /// </summary>
    /// <param name="item"></param>
    /// <param name="batch"></param>
    /// <returns></returns>
    Dictionary<int, double?> CalculateUnitCosts(SheetItem item, EstimationBatch batch);
    /// <summary>
    /// Diactionare int as ResourceType, double as UnitResourceCost
    /// </summary>
    /// <param name="item"></param>
    /// <param name="batch"></param>
    /// <returns></returns>
    Dictionary<int, double?> CalculateTotalCosts(SheetItem item, EstimationBatch batch);
}
