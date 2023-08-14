using BidCon.SDK;
using BidConReport.Shared.DTOs;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
public interface IEstimationItemRulesEngine
{
    bool ShouldBeProcessed(BidCon.SDK.EstimationItem estimationItem, EstimationImportSettingsDTO settings);
}