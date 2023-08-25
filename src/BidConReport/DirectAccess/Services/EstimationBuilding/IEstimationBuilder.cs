using BidConReport.BidconAccess.Enteties.EstimationBuild;
using BidConReport.BidconAccess.Enteties.QueryResults;

namespace BidConReport.BidconAccess.Services.EstimationBuilding;
public interface IEstimationBuilder
{
    Estimation Build(EstimationBatch batch);
}