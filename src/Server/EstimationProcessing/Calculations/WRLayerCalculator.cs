using AppPlatform.Shared.DTOs.BidconAccess;
using AppPlatform.Shared.Enums.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public class WRLayerCalculator : ILayerCostCalculator
{
    public void Calculate(BC_EstimationBatchDto batch, string layerId, out double unitCost, out double unitAskingPrice)
    {
        unitCost = 0;
        unitAskingPrice = 0;
        var layerItems = batch.WRLayers.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            var resource = batch.Resources.Single(x => x.Id == item.LayerId);
            var wasteFactor = 1 + item.Waste / 100.0;
            var objectFactor = resource.ResourceType == (int)ResourceType.Arbetare ? batch.Estimation.ObjectFactor : 1;
            var cost = resource.Price * item.Cons * item.ConsFactor * wasteFactor * objectFactor;
            unitCost += cost;
            unitAskingPrice += cost * AskingPriceResourceFactor(batch, resource.ResourceType);
        }
    }

    public Dictionary<int, double?> Calculate(BC_EstimationBatchDto batch, string layerId)
    {
        var activeLayerItems = batch.WRLayers.Where(x => x.Id == layerId).ToList();
        Dictionary<int, double?> costs = new();
        foreach (var item in activeLayerItems)
        {
            var resource = batch.Resources.Single(x => x.Id == item.LayerId);
            var wasteFactor = 1 + item.Waste / 100.0;

            //Investigate if this is how objectFactor is applied always
            var objectFactor = resource.ResourceType == (int)ResourceType.Arbetare ? batch.Estimation.ObjectFactor : 1;

            var calculatedCost = resource.Price * item.Cons * item.ConsFactor * wasteFactor * objectFactor;

            if (costs.ContainsKey(resource.ResourceType))
            {
                costs[resource.ResourceType] += calculatedCost;
            }
            else
            {
                costs[resource.ResourceType] = calculatedCost;
            }
        }
        return costs;
    }

    private double AskingPriceResourceFactor(BC_EstimationBatchDto batch, int resourceType)
    {
        return batch.ResourceFactors.Where(x => x.ResourceType == resourceType).Select(x => x.Factor).First();
    }
}
