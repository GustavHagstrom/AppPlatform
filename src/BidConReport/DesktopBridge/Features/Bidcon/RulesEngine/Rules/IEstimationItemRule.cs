using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public interface IEstimationItemRule
{
    bool Run(EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine);
}
