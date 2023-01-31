using BidCon.SDK;
using SharedLibrary.Models;

namespace DesktopBridge.Features.Bidcon.Factories;
public interface ISimpleEstimationFactory
{
    SimpleEstimation CreateSimpleEstimation(Estimation estimation, EstimationImportSettings settings);
}