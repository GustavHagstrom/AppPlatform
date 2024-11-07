using AppPlatform.BidconDatabaseAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Calculations;
public interface ILayerCostCalculator
{
    void Calculate(D_EstimationBatch batch, string layerId, out double unitCost, out double unitAskingPrice);
    /// <summary>
    /// Diactionare int as ResourceType, double as UnitResourceCost
    /// </summary>
    /// <param name="batch"></param>
    /// <param name="layerId"></param>
    /// <returns></returns>
    Dictionary<int, double?> Calculate(D_EstimationBatch batch, string layerId);
}
