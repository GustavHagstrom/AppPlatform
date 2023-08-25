using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.QueryResults;

namespace BidConReport.BidconAccess.Services.EstimationBuilding;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(EstimationSheetResult sheetResult, EstimationBatch batch);
}