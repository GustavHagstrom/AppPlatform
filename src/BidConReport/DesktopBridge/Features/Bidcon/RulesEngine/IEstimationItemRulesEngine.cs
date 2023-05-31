using BidCon.SDK;
using BidConReport.Shared.Entities;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
public interface IEstimationItemRulesEngine
{
    bool ShouldBeProcessed(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettings settings);
}