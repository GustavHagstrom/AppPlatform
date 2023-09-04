using BidConReport.Client.Shared.EstimationViewTemplate.Models;

namespace BidConReport.Client.Shared.EstimationViewTemplate.Services;

public class EstimationViewTemplateService : IEstimationViewTemplateServices
{
    public async Task UpsertAsync(Models.ViewTemplate estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(Models.ViewTemplate estimationReport, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<Models.ViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Models.ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
