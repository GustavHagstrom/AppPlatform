using Client.Shared.EstimationViewTemplate.Models;

namespace Client.Shared.EstimationViewTemplate.Services;
public interface IEstimationViewTemplateServices
{
    Task DeleteAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken);
    Task<IEnumerable<ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken);
    Task<ViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken);
    Task UpsertAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken);
}