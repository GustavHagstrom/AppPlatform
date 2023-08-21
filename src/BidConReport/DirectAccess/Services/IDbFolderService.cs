using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;

namespace BidConReport.DirectAccess.Services;
public interface IDbFolderService
{
    DbFolder CreateFromBatch(EstimationFolderBatch batch);
}