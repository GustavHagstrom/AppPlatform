using BidCon.SDK;
using BidConReport.SharedLibrary.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
public interface IEstimationItemRulesEngine
{
    bool ShouldBeProcessed(EstimationItem estimationItem, EstimationImportSettings settings);
}