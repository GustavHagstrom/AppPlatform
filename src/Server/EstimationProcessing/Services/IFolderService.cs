using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(D_EstimationFolderBatch batch);
}