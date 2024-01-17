﻿using SharedLibrary.DTOs.BidconAccess;

namespace Server.EstimationProcessing.Calculations;
public class DELayerCalculator : ILayerCostCalculator
{
    private readonly WRLayerCalculator _wRLayerCalculator = new();
    public void Calculate(BC_EstimationBatchDto batch, string layerId, out double unitCost, out double unitAskingPrice)
    {
        unitCost = 0;
        unitAskingPrice = 0;
        var layerItems = batch.DELayers.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            _wRLayerCalculator.Calculate(batch, item.LayerId, out double layerUnitCost, out double layerAskingPrice);
            unitCost += layerUnitCost;
            unitAskingPrice += layerAskingPrice;
        }
    }

    public Dictionary<int, double?> Calculate(BC_EstimationBatchDto batch, string layerId)
    {
        var activeLayerItems = batch.DELayers.Where(item => item.Id == layerId);
        Dictionary<int, double?> costs = new();
        foreach (var layerItem in activeLayerItems)
        {
            var calculatedCosts = _wRLayerCalculator.Calculate(batch, layerItem.LayerId);
            foreach (var cost in calculatedCosts)
            {
                if (costs.ContainsKey(cost.Key))
                {
                    costs[cost.Key] += cost.Value * layerItem.Cons;
                }
                else
                {
                    costs[cost.Key] = cost.Value * layerItem.Cons;
                }
            }
        }
        return costs;
    }
}