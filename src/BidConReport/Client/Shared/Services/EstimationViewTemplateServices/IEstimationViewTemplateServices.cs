using BidConReport.Client.Shared.Services.EstimationViewTemplateServices.Models;

namespace BidConReport.Client.Shared.Services.EstimationViewTemplateServices;
public interface IEstimationViewTemplateServices
{
    Task DeleteAsync(EstimationViewTemplate estimationReport, CancellationToken cancellationToken);
    Task<IEnumerable<EstimationViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken);
    Task<EstimationViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(EstimationViewTemplate estimationReport, CancellationToken cancellationToken);
}