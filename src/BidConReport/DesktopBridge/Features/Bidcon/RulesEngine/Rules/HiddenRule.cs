using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class HiddenRule : IEstimationItemRule
{
    public bool Run(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettingsDTO settings, IEstimationItemRulesEngine engine)
    {
        return !estimationItem.Remark.ToLower().Contains(settings.HiddenTag.ToLower());
    }
}
