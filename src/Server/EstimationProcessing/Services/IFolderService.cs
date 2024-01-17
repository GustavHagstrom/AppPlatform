using AppPlatform.Server.EstimationProcessing.Models;
using SharedLibrary.DTOs.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}