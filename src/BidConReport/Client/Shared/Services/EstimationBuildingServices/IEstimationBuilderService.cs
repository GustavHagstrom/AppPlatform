using BidConReport.BidconAccess.Enteties.QueryResults;
using BidConReport.Client.Shared.Services.EstimationBuildingServices.Models;

namespace BidConReport.Client.Shared.Services.EstimationBuildingServices;
public interface IEstimationBuilderService
{
    Estimation Build(EstimationBatch batch);
}