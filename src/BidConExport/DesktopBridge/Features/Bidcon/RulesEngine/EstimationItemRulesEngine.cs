using BidCon.SDK;
using DesktopBridge.Features.Bidcon.RulesEngine.Rules;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine;
public class EstimationItemRulesEngine : IEstimationItemRulesEngine
{
    private readonly List<IEstimationItemRule> _rules;
    public EstimationItemRulesEngine()
    {
        _rules = new()
        {
            new HiddenRule(),
            new IsActiveRule(),
            new ProcessIfContainerRule(),
        };
    }
    public bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings)
    {
        foreach (var rule in _rules)
        {
            if (rule.Run(estimationItem, settings, this) == false)
            {
                return false;
            }
        }
        return true;
    }
}
