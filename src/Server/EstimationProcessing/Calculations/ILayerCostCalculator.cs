using AppPlatform.BidconDataAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerCostCalculator
{
    void Calculate(EstimationBatch batch, string layerId, out double unitCost, out double unitAskingPrice);
    /// <summary>
    /// Diactionare int as ResourceType, double as UnitResourceCost
    /// </summary>
    /// <param name="batch"></param>
    /// <param name="layerId"></param>
    /// <returns></returns>
    Dictionary<int, double?> Calculate(EstimationBatch batch, string layerId);
}
