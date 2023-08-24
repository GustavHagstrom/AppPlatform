using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enums;
using BidConReport.BidconDatabaseAccess.Services.CostCalculation.SheetItemClalcuation;

namespace BidConReport.BidconDatabaseAccess.Services.CostCalculation;
public class EstimationCostService
{
    private readonly Dictionary<int, ISheetItemCostCalculator> _calculatorMap; 
    public EstimationCostService()
    {
        _calculatorMap = new()
        {
            { (int)RowType.Group, new GroupCalculator(this) },
            { (int)RowType.Part, new PartCalculator(this) },
            { (int)RowType.LayeredItem, new LayerdItemCalculator() },
        };
    }
    public Dictionary<int, double?> UnitCosts(SheetItem item, EstimationBatch batch)
    {
        if (_calculatorMap.ContainsKey(item.RowType))
        {
            return _calculatorMap[item.RowType].CalculateUnitCosts(item, batch);
        }
        return new();
    }
    public Dictionary<int, double?> TotalCosts(SheetItem item, EstimationBatch batch)
    {
        if (_calculatorMap.ContainsKey(item.RowType))
        {
            return _calculatorMap[item.RowType].CalculateTotalCosts(item, batch);
        }
        return new();
    }
}
