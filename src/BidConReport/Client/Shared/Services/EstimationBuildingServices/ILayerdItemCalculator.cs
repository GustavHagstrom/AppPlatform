using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.QueryResults;

namespace BidConReport.Client.Shared.Services.EstimationBuildingServices;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(EstimationSheetResult sheetResult, EstimationBatch batch);
}