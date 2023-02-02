using BidCon.SDK;
using BidConReport.SharedLibrary.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class IsActiveRule : IEstimationItemRule
{
    public bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return estimationItem.IsActive;
    }
}
