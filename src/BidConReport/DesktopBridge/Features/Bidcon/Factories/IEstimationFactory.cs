using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface IEstimationFactory
{
    Shared.Models.Estimation CreateSimpleEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettings settings);
}