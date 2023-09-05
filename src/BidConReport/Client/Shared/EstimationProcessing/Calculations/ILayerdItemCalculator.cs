using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Shared.EstimationProcessing.Calculations;
public interface ILayerdItemCalculator
{
    Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheetDto sheetResult, BC_EstimationBatchDto batch);
}