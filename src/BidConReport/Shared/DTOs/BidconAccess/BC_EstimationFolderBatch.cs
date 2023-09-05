namespace BidConReport.Shared.DTOs.BidconAccess;
public record BC_EstimationFolderBatch(IEnumerable<BC_EstimationDto> Estimations, IEnumerable<BC_EstimationFolderDto> Folders);