using SharedLibrary.DTOs.BidconAccess;
using SharedLibrary.Enums.BidconAccess;

namespace Client.Shared.EstimationProcessing.Calculations;
public class MELayerCalculator : ILayerCostCalculator
{
    private readonly WRLayerCalculator _wRLayerCalculator = new();
    private readonly DELayerCalculator _dELayerCalculator = new();
    public void Calculate(BC_EstimationBatchDto batch, string layerId, out double unitCost, out double unitAskingPrice)
    {
        unitCost = 0;
        unitAskingPrice = 0;
        var layerItems = batch.MELayers.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            if (item.LayerType == (int)LayerType.DesignElement)
            {
                _dELayerCalculator.Calculate(batch, item.LayerId, out double layerUnitCost, out double layerAskingPrice);
                unitCost += layerUnitCost;
                unitAskingPrice += layerAskingPrice;
            }
            else if (item.LayerType == (int)LayerType.WorkResult)
            {
                _wRLayerCalculator.Calculate(batch, item.LayerId, out double layerUnitCost, out double layerAskingPrice);
                unitCost += layerUnitCost;
                unitAskingPrice += layerAskingPrice;
            }
        }
    }

    public Dictionary<int, double?> Calculate(BC_EstimationBatchDto batch, string layerId)
    {
        var activeLayerItems = batch.MELayers
            .Where(item => item.Id == layerId);
        Dictionary<int, double?> costs = new();
        foreach (var item in activeLayerItems)
        {
            Dictionary<int, double?> calculatedCosts;
            if (item.LayerType == (int)LayerType.DesignElement)
            {
                calculatedCosts = _dELayerCalculator.Calculate(batch, item.LayerId);
            }
            else if (item.LayerType == (int)LayerType.WorkResult)
            {
                calculatedCosts = _wRLayerCalculator.Calculate(batch, item.LayerId);
            }
            else
            {
                throw new InvalidOperationException();
            }

            foreach (var cost in calculatedCosts)
            {
                if (costs.ContainsKey(cost.Key))
                {
                    costs[cost.Key] += cost.Value * item.Cons;
                }
                else
                {
                    costs[cost.Key] = cost.Value * item.Cons;
                }
            }
        }
        return costs;
    }
}
