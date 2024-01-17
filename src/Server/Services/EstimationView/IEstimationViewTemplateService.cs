using SharedLibrary.DTOs.EstimationView;

namespace AppPlatform.Server.Services.EstimationView;
public interface IEstimationViewTemplateService
{
    Task DeleteAsync(Guid id, string organizationId);
    Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsDeepListAsync(string organizationId);
    Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsShallowListAsync(string organizationId);
    Task<EstimationViewTemplateDto?> GetSingleDeepAsync(Guid id, string organizationId);
    Task UpsertAsync(EstimationViewTemplateDto dto, string organizationId);
}