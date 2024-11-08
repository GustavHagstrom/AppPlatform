namespace AppPlatform.BidconDatabaseAccess.DbAccess.Models;
internal record EstimationFolderBatch
    (IEnumerable<Estimation> Estimations, IEnumerable<EstimationFolder> Folders);