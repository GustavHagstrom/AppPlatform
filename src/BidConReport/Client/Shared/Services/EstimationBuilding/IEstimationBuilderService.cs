using BidConReport.BidconAccess.Enteties.QueryResults;
using BidConReport.Client.Shared.Services.EstimationBuilding.Models;

namespace BidConReport.Client.Shared.Services.EstimationBuilding;
public interface IEstimationBuilderService
{
    Estimation Build(EstimationBatch batch);
}