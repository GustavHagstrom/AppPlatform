namespace AppPlatform.BidconDatabaseAccess.DbAccess.Models;
internal record EstimationFolderBatch
    (IEnumerable<B_Estimation> Estimations, IEnumerable<EstimationFolder> Folders);