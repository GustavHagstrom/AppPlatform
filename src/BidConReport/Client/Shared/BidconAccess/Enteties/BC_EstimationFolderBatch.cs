namespace BidConReport.Client.Shared.BidconAccess.Enteties;
public record BC_EstimationFolderBatch(IEnumerable<BC_Estimation> Estimations, IEnumerable<BC_EstimationFolder> Folders);