using AppPlatform.Core.DTOs.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheetDto sheetResult, BC_EstimationBatchDto batch);
}