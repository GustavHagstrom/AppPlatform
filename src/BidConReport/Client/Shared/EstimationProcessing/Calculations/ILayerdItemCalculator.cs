using BidConReport.Client.Shared.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheet sheetResult, EstimationBatch batch);
}