using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.QueryResults;
using BidConReport.BidconAccess.Enums;

namespace BidConReport.BidconAccess.Services.EstimationBuilding;
public class LayerdItemCalculator : ILayerdItemCalculator
{
    private readonly Dictionary<int, ILayerCostCalculator> _calculatorMap = new()
    {
        { (int)LayerType.WorkResult, new WRLayerCalculator() },
        { (int)LayerType.DesignElement, new DELayerCalculator() },
        { (int)LayerType.MixedElement, new MELayerCalculator() },
    };
    public Dictionary<int, double?> CalculateUnitCosts(EstimationSheetResult sheetResult, EstimationBatch batch)
    {
        if (sheetResult.LayerType is null)
        {
            return new();
        }
        return _calculatorMap[sheetResult.LayerType.Value].Calculate(batch, sheetResult.LayerId);
    }
}
