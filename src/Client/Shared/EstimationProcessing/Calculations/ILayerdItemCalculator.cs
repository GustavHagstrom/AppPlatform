using SharedLibrary.DTOs.BidconAccess;

namespace Client.Shared.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheetDto sheetResult, BC_EstimationBatchDto batch);
}