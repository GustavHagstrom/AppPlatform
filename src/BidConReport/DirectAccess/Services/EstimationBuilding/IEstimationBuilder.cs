using BidConReport.BidconDatabaseAccess.Enteties.EstimationBuild;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;

namespace BidConReport.BidconDatabaseAccess.Services.EstimationBuilding;
public interface IEstimationBuilder
{
    Estimation Build(EstimationBatch batch);
}