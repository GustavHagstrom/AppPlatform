namespace BidConReport.BidconAccess.Enteties;
public record EstimationFolderBatch(IEnumerable<Estimation> Estimations, IEnumerable<EstimationFolder> Folders);