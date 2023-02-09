using BidCon.SDK;
using BidConReport.Shared.Models;
using BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
public class EstimationItemRulesEngine : IEstimationItemRulesEngine
{
    private readonly List<IEstimationItemRule> _rules = new()
        {
            new HiddenRule(),
            new IsActiveRule(),
            new ProcessIfContainerRule(),
        };

    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings)
    {
        foreach (var rule in _rules)
        {
            if (!rule.Run(estimationItem, settings, this))
            {
                return false;
            }
        }
        return true;
    }
}
