using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class IsActiveRule : IEstimationItemRule
{
    public bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return estimationItem.IsActive;
    }
}
