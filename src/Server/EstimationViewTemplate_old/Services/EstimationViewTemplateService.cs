using AppPlatform.Server.EstimationViewTemplate_old.Models;
using Mapster;
using AppPlatform.Shared.Constants;
using AppPlatform.Shared.DTOs.EstimationView;
using AppPlatform.Shared.Wrappers;
using System.Net.Http.Json;

namespace AppPlatform.Server.EstimationViewTemplate_old.Services;

public class EstimationViewTemplateService : IEstimationViewTemplateServices
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<EstimationViewTemplateService> _logger;

    public EstimationViewTemplateService(IHttpClientWrapper httpClient, ILogger<EstimationViewTemplateService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task UpsertAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken = default)
    {
        var dto = viewTemplate.Adapt<EstimationViewTemplateDto>();
        var result = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.EstimationViewTemplateController.Upsert, dto, cancellationToken);
        result.EnsureSuccessStatusCode();
    }
    public async Task DeleteAsync(ViewTemplate viewTemplate, CancellationToken cancellationToken = default)
    {
        var result = await _httpClient.DeleteAsync(BackendApiEndpoints.EstimationViewTemplateController.Delete + $"?id={viewTemplate.Id}", cancellationToken);
        result.EnsureSuccessStatusCode();
    }
    public async Task<ViewTemplate> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var requestUri = (BackendApiEndpoints.EstimationViewTemplateController.Get + $"?id={id}");
        var response = await _httpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<EstimationViewTemplateDto>();
        return result!.Adapt<ViewTemplate>();
    }
    public async Task<IEnumerable<ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BackendApiEndpoints.EstimationViewTemplateController.GetShallowList, cancellationToken);
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return Array.Empty<ViewTemplate>();
        }
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<EstimationViewTemplateDto>>();
        return result!.Adapt<IEnumerable<ViewTemplate>>();
    }
}
