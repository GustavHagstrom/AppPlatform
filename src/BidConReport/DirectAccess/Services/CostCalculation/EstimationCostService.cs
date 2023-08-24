using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enums;
using BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation;
public class EstimationCostService
{
    private readonly Dictionary<int, ISheetItemCostCalculator> _calculatorMap = new()
    {
        { (int)RowType.Group, new GroupCalculator() },
        { (int)RowType.Part, new PartCalculator() },
        { (int)RowType.LayeredItem, new LayerdItemCalculator() },
    };
    public Dictionary<int, double?> GetUnitCosts(SheetItem item, EstimationBatch batch)
    {
        if (_calculatorMap.ContainsKey(item.RowType))
        {
            return _calculatorMap[item.Row].CalculateUnitCosts(item, batch);
        }
        return new();
    }
}
