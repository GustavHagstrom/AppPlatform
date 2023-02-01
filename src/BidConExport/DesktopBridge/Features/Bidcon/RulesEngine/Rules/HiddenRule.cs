using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class HiddenRule : IEstimationItemRule
{
    public bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return !estimationItem.Remark.ToLower().Contains(settings.HiddenTag.ToLower());
    }
}
