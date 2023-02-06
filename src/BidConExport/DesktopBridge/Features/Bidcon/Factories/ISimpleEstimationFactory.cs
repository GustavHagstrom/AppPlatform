using BidCon.SDK;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface ISimpleEstimationFactory
{
    SimpleEstimation CreateSimpleEstimation(Estimation estimation, EstimationImportSettings settings);
}