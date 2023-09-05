using BidConReport.Client.Shared.EstimationProcessing.Models;
using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Shared.EstimationProcessing.Services;
public interface IFolderService
{
    Folder CreateFromBatch(BC_EstimationFolderBatch batch);
}