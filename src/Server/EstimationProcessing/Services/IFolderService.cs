using AppPlatform.Core.DTOs.BidconAccess;
using AppPlatform.Server.EstimationProcessing.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}