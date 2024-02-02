using AppPlatform.BidconDataAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheet sheetResult, BC_EstimationBatch batch);
}