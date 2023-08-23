using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;

namespace BidConReport.BidconDatabaseAccess.Services;
public interface IDbFolderService
{
    DbFolder CreateFromBatch(EstimationFolderBatch batch);
}