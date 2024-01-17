using AppPlatform.Server.EstimationProcessing.Models;
using AppPlatform.Shared.DTOs.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}