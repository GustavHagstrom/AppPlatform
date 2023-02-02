using BidCon.SDK;
using BidConReport.SharedLibrary.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public interface ISimpleEstimationFactory
{
    SimpleEstimation CreateSimpleEstimation(Estimation estimation, EstimationImportSettings settings);
}