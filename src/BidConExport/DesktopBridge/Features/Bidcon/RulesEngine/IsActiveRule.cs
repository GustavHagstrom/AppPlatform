using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine;
public class IsActiveRule : IEstimationItemRule
{
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return estimationItem.IsActive;
    }
}
