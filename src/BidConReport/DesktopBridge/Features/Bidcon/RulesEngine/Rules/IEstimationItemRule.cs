using BidCon.SDK;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public interface IEstimationItemRule
{
    bool Run(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettings settings, IEstimationItemRulesEngine engine);
}
