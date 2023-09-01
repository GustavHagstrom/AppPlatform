using BidConReport.Client.Shared.Services.EstimationReportServices.Models;

namespace BidConReport.Client.Shared.Services.EstimationReportServices;
public interface IEstimationReportService
{
    Task DeleteAsync(EstimationReport estimationReport, CancellationToken cancellationToken);
    Task<IEnumerable<EstimationReport>> GetAllShallowAsync(CancellationToken cancellationToken);
    Task<EstimationReport> GetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(EstimationReport estimationReport, CancellationToken cancellationToken);
}