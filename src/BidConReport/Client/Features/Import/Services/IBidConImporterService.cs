using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Services;
public interface IBidConImporterService
{
    //Task<BidConImportResult<Estimation>> GetEstimationAsync(string id, EstimationImportSettings settings);
    Task<IEnumerable<BidConImportResult<Estimation>>> GetEstimationsAsync(IEnumerable<string> ids, EstimationImportSettings settings);
    Task<BidConImportResult<DbFolder>> GetFoldersAsync();
}