using Client.Shared.EstimationViewTemplate.Models;

namespace Client.Shared.EstimationViewTemplate.Services;
public interface IEstimationViewTemplateServices
{
    Task DeleteAsync(Models.ViewTemplate estimationReport, CancellationToken cancellationToken);
    Task<IEnumerable<Models.ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken);
    Task<Models.ViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(Models.ViewTemplate estimationReport, CancellationToken cancellationToken);
}