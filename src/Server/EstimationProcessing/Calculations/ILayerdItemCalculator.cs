using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(D_EstimationSheet sheetResult, D_EstimationBatch batch);
}