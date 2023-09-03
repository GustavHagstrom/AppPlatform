namespace BidConReport.Shared.DTOs.BidconAccess;
public record EstimationFolderBatchDto(IEnumerable<EstimationDto> Estimations, IEnumerable<EstimationFolderDto> Folders);