using BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models;

namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices;

public class EstimationReportService : IEstimationReportService
{
    public async Task UpsertAsync(EstimationReport estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(EstimationReport estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<EstimationReport> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<EstimationReport>> GetAllShallowAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
