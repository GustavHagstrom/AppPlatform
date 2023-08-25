using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enums;

namespace BidConReport.BidconDatabaseAccess.Services.EstimationBuilding;
public class WRLayerCalculator : ILayerCostCalculator
{
    public void Calculate(EstimationBatch batch, string layerId, out double unitCost, out double unitAskingPrice)
    {
        unitCost = 0;
        unitAskingPrice = 0;
        var layerItems = batch.WRLayer.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            var resource = batch.Resource.Single(x => x.Id == item.LayerId);
            var wasteFactor = 1 + item.Waste / 100.0;
            var objectFactor = resource.ResourceType == (int)ResourceType.Arbetare ? batch.Estimation.ObjectFactor : 1;
            var cost = resource.Price * item.Cons * item.ConsFactor * wasteFactor * objectFactor;
            unitCost += cost;
            unitAskingPrice += cost * AskingPriceResourceFactor(batch, resource.ResourceType);
        }
    }

    public Dictionary<int, double?> Calculate(EstimationBatch batch, string layerId)
    {
        var activeLayerItems = batch.WRLayer.Where(x => x.Id == layerId).ToList();
        Dictionary<int, double?> costs = new();
        foreach (var item in activeLayerItems)
        {
            var resource = batch.Resource.Single(x => x.Id == item.LayerId);
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

    private double AskingPriceResourceFactor(EstimationBatch batch, int resourceType)
    {
        return batch.ResourceFactors.Where(x => x.ResourceType == resourceType).Select(x => x.Factor).First();
    }
}
