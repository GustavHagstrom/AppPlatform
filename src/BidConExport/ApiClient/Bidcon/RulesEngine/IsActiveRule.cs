using BidCon.SDK;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.RulesEngine;
public class IsActiveRule : IEstimationItemRule
{
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return estimationItem.IsActive;
    }
}
