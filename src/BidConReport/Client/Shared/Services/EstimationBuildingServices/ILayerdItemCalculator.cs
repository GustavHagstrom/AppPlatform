using BidConReport.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.Services.EstimationBuildingServices;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(EstimationSheet sheetResult, EstimationBatch batch);
}