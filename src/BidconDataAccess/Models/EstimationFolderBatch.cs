namespace AppPlatform.BidconDataAccess.Models;
public record EstimationFolderBatch(IEnumerable<Estimation> Estimations, IEnumerable<EstimationFolder> Folders);