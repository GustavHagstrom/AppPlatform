using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(EstimationSheet sheetResult, EstimationBatch batch);
}