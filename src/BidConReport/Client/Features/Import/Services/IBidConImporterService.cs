using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidConImporterService
{
    Task<IEnumerable<BidConImportResultDTO<EstimationDTO>>> GetEstimationsAsync(IEnumerable<DbEstimationDTO> estimations, EstimationImportSettingsDto settings, CancellationToken cancelToken, IProgress<BidConImportResultDTO<EstimationDTO>>? progress = null);
    Task<BidConImportResultDTO<EstimationDTO>> GetEstimationAsync(BidconImportRequestDTO request, CancellationToken cancelToken);
    Task<BidConImportResultDTO<DbFolderDTO>> GetFoldersAsync();
}