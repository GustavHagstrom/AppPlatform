using AppPlatform.Server.EstimationProcessing.Models;
using AppPlatform.BidconDataAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BC_EstimationBatch batch);
}