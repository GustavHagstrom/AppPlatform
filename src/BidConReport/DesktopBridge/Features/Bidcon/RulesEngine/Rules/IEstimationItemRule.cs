using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine.Rules;
public interface IEstimationItemRule
{
    bool Run(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettingsDto settings, IEstimationItemRulesEngine engine);
}
