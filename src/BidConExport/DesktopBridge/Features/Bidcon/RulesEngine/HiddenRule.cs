using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine;
public class HiddenRule : IEstimationItemRule
{
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return !estimationItem.Remark.ToLower().Contains(settings.HiddenTag.ToLower());
    }
}
