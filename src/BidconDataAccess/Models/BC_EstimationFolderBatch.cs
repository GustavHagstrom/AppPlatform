namespace AppPlatform.BidconDataAccess.Models;
public record BC_EstimationFolderBatch(IEnumerable<BC_Estimation> Estimations, IEnumerable<BC_EstimationFolder> Folders);