using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Logic;
public interface IBidConImporter
{
    Task<BidConImportResult<SimpleEstimation>> GetEstimationAsync(string id, EstimationImportSettings settings);
    Task<BidConImportResult<IEnumerable<DbEstimation>>> GetEstimationsAsync();
    Task<BidConImportResult<DbFolder>> GetFoldersAsync();
}