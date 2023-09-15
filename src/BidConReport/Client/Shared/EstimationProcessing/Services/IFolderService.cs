using Client.Shared.EstimationProcessing.Models;
using SharedLibrary.DTOs.BidconAccess;

namespace Client.Shared.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}