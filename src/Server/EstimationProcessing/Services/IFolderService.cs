using Server.EstimationProcessing.Models;
using SharedLibrary.DTOs.BidconAccess;

namespace Server.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}