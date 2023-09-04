﻿using BidConReport.Client.Shared.BidconAccess.Enteties;

namespace BidConReport.Client.Shared.EstimationProcessing.Calculations;
public interface ILayerCostCalculator
{
    void Calculate(BC_EstimationBatch batch, string layerId, out double unitCost, out double unitAskingPrice);
    /// <summary>
    /// Diactionare int as ResourceType, double as UnitResourceCost
    /// </summary>
    /// <param name="batch"></param>
    /// <param name="layerId"></param>
    /// <returns></returns>
    Dictionary<int, double?> Calculate(BC_EstimationBatch batch, string layerId);
}
