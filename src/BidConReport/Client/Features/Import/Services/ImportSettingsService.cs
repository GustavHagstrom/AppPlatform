using BidConReport.Shared.Constants;
using BidConReport.Shared.Entities;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Services;

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
            var result = await client.DeleteAsync($"{BackendApiEndpoints.ImportEndpoints.Delete}/{settingsId}");
            result.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to delete import settings: {ex.Message}");
        }
    }

    public async Task<ICollection<EstimationImportSettings>> GetAllAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var requestUri = BackendApiEndpoints.ImportEndpoints.All;
            var response = await client.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var settings = await response.Content.ReadFromJsonAsync<ICollection<EstimationImportSettings>>();
            return settings ?? throw new Exception("Response was null");
        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Failed to retrieve import settings: {ex.Message}");
        }
    }

    public async Task<EstimationImportSettings> GetStandardAsync()
    {
        
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var requestUri = BackendApiEndpoints.ImportEndpoints.Default;
            var result = await client.GetAsync(requestUri);
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadFromJsonAsync<EstimationImportSettings>();
            return content!;
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it in some other way.
            throw new Exception($"Failed to retrieve standard import settings: {ex.Message}");
        }
    }

    public async Task SaveAsStandardAsync(EstimationImportSettings? settings)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var result = await client.PostAsJsonAsync(BackendApiEndpoints.ImportEndpoints.SetDefault, settings?.Id);
            result.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            // Log the exception or handle it appropriately.
            throw new Exception("An error occurred while saving the standard import setting.", ex);
        }
    }

    public async Task UpsertAsync(EstimationImportSettings settings)
    {
        try
        {
            var client = _httpClientFactory.CreateClient(HttpClientNames.BackendHttpClientName);
            var result = await client.PostAsJsonAsync(BackendApiEndpoints.ImportEndpoints.Upsert, settings);
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
