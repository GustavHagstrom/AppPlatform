namespace AppPlatform.BidconDatabaseAccess.Models;
public record D_EstimationFolderBatch
    (IEnumerable<D_Estimation> Estimations, IEnumerable<D_EstimationFolder> Folders);