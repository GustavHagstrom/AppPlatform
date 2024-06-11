namespace AppPlatform.BidconDatabaseAccess.Models;
public record EstimationFolderBatch(IEnumerable<Estimation> Estimations, IEnumerable<EstimationFolder> Folders);