using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class ProcessIfContainerRule : IEstimationItemRule
{
    public bool Run(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettingsDTO settings, IEstimationItemRulesEngine engine)
    {
        if (estimationItem.ItemType != BidCon.SDK.EstimationItemType.Group || estimationItem.ItemType != BidCon.SDK.EstimationItemType.Part) return true;

        foreach (var subItem in estimationItem.Items)
        {
            if (engine.ShouldBeProcessed(subItem, settings))
            {
                return true;
            }
        }
        return false;
    }
}
