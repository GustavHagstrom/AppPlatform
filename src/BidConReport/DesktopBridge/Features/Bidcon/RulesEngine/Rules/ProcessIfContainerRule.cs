using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public class ProcessIfContainerRule : IEstimationItemRule
{
    public bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        if (estimationItem.ItemType != EstimationItemType.Group || estimationItem.ItemType != EstimationItemType.Part) return true;

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
