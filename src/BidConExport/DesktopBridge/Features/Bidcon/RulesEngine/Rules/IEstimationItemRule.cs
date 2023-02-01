using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public interface IEstimationItemRule
{
    bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine);
}
