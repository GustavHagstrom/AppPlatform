using SharedLibrary.Wrappers;

namespace Client.Shared.EstimationViewTemplate.Services;

public class EstimationViewTemplateService : IEstimationViewTemplateServices
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<EstimationViewTemplateService> _logger;

    public EstimationViewTemplateService(IHttpClientWrapper httpClient, ILogger<EstimationViewTemplateService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
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
