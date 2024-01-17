using SharedLibrary.DTOs.BidconAccess;
using SharedLibrary.Enums.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public class LayerdItemCalculator : ILayerdItemCalculator
{
    private readonly Dictionary<int, ILayerCostCalculator> _calculatorMap = new()
    {
        { (int)LayerType.WorkResult, new WRLayerCalculator() },
        { (int)LayerType.DesignElement, new DELayerCalculator() },
        { (int)LayerType.MixedElement, new MELayerCalculator() },
    };
    public Dictionary<int, double?> CalculateUnitCosts(BC_EstimationSheetDto sheetResult, BC_EstimationBatchDto batch)
    {
        if (sheetResult.LayerType is null)
        {
            return new();
        }
        return _calculatorMap[sheetResult.LayerType.Value].Calculate(batch, sheetResult.LayerId);
    }
}
