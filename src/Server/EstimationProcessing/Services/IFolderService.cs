using AppPlatform.BidconDataAccess.Models;
using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(EstimationFolderBatch batch);
}