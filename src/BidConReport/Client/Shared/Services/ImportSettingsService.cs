﻿using BidConReport.Client.Shared.Constants;
using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services;

public class ImportSettingsService : IImportSettingsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<ImportSettingsService> _logger;

    public ImportSettingsService(IHttpClientFactory httpClientFactory, ILogger<ImportSettingsService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task DeleteAsync(int settingsId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var result = await client.DeleteAsync($"{BackendApiEndpoints.ImportController.Delete}/{settingsId}");
            result.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to delete import settings: {ex.Message}");
        }
    }

    public async Task<ICollection<EstimationImportSettingsDto>> GetAllAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var requestUri = BackendApiEndpoints.ImportController.All;
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var settings = await response.Content.ReadFromJsonAsync<ICollection<EstimationImportSettingsDto>>();
            return settings ?? throw new Exception("Response was null");
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to retrieve import settings: {ex.Message}");
        }
    }

    public async Task<EstimationImportSettingsDto?> GetDefaultAsync()
    {

        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var requestUri = BackendApiEndpoints.ImportController.Default;
            var result = await client.GetAsync(requestUri);
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadFromJsonAsync<EstimationImportSettingsDto>();
            return content!;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it in some other way.
            _logger.LogError(ex, "Failed to retrieve standard import settings");
            return null;
        }
    }

    public async Task SaveAsDefaultAsync(EstimationImportSettingsDto? settings)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var result = await client.PostAsJsonAsync(BackendApiEndpoints.ImportController.SetDefault, settings);
            result.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it appropriately.
            _logger.LogError(ex, "An error occurred while saving the standard import setting.");
            throw;
        }
    }

    public async Task UpsertAsync(EstimationImportSettingsDto settings)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var result = await client.PostAsJsonAsync(BackendApiEndpoints.ImportController.Upsert, settings);
            //var test = "test";
            //var result = await client.PostAsJsonAsync("/api/import/UpdateOrCreateImportSettings", test);
            result.EnsureSuccessStatusCode();
        }
        catch (Exception ex) when (ex is HttpRequestException || ex is OperationCanceledException)
        {
            // Log the exception or handle it appropriately.
            throw new Exception("An error occurred while saving import setting.", ex);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Undexpeced error", e.Message);
            throw;
        }
    }
}
