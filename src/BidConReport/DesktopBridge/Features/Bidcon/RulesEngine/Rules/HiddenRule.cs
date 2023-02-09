using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class HiddenRule : IEstimationItemRule
{
    public bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return !estimationItem.Remark.ToLower().Contains(settings.HiddenTag.ToLower());
    }
}
