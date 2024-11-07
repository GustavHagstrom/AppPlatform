using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IEstimationBuilderService
{
    Estimation Build(BidconDatabaseAccess.Models.D_EstimationBatch batch);
}