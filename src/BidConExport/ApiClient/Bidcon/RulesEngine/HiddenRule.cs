using BidCon.SDK;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.RulesEngine;
public class HiddenRule : IEstimationItemRule
{
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine)
    {
        return !estimationItem.Remark.ToLower().Contains(settings.HiddenTag.ToLower());
    }
}
