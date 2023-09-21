using Client.Shared.EstimationViewTemplate.Models;

namespace Client.Shared.EstimationViewTemplate.Services;
public interface IEstimationViewTemplateServices
{
    Task DeleteAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken = default);
    Task<IEnumerable<ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken = default);
    Task<ViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpsertAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken = default);
}