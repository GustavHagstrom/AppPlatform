using BidConReport.BidconAccess.Enteties.EstimationBuild;
using BidConReport.BidconAccess.Enteties.QueryResults;

namespace BidConReport.BidconAccess.Services;
public interface IDbFolderService
{
    DbFolder CreateFromBatch(EstimationFolderBatch batch);
}