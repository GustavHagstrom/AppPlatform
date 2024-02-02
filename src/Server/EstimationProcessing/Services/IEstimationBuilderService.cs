using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BidconDataAccess.Models.EstimationBatch batch);
}