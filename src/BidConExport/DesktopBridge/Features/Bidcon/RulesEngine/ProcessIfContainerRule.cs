using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine;
public class ProcessIfContainerRule : IEstimationItemRule
{
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        if (estimationItem.ItemType != EstimationItemType.Group || estimationItem.ItemType != EstimationItemType.Part) return true;

        foreach (var item in estimationItem.Items)
        {
            if (engine.ShouldBeProcessed(item, settings))
            {
                return true;
            }
        }
        return false;
    }
}
