using BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models;

namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices;

public class EstimationViewTemplateService : IEstimationViewTemplateServices
{
    public async Task UpsertAsync(EstimationViewTemplate estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(EstimationViewTemplate estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<EstimationViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<EstimationViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
