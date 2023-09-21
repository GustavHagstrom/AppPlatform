﻿using Client.Shared.EstimationViewTemplate.Models;
using Mapster;
using SharedLibrary.Constants;
using SharedLibrary.DTOs.EstimationView;
using SharedLibrary.Wrappers;
using System.Net.Http.Json;

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
        var result = await response.Content.ReadFromJsonAsync<ViewTemplate>();
        return result!;
    }
    public async Task<IEnumerable<ViewTemplate>> GetAllShallowAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BackendApiEndpoints.EstimationViewTemplateController.GetShallowList, cancellationToken);
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return Array.Empty<ViewTemplate>();
        }
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<ViewTemplate>>();
        return result!;
    }
}
