using BidCon.SDK;
using SharedLibrary.Models;

namespace ApiClient.Bidcon.Factories;
public interface ISimpleEstimationFactory
{
    SimpleEstimation CreateSimpleEstimation(Estimation estimation, EstimationImportSettings settings);
}