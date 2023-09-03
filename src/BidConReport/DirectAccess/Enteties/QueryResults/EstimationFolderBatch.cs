namespace BidConReport.BidconAccess.Enteties.QueryResults;
public record EstimationFolderBatch(IEnumerable<Estimation> Estimations, IEnumerable<EstimationFolder> Folders);