using BidConReport.Shared;
using BidConReport.Shared.Models;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Services;

public class ImportSettingsService : IImportSettingsService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ImportSettingsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task DeleteAsync(int settingsId)
    {
        var client = _httpClientFactory.CreateClient(AppConstants.BackendHttpClientName);
        var result = await client.DeleteAsync($"/api/import/DeleteImportSetting/{settingsId}");
        if(!result.IsSuccessStatusCode)
        {
            throw new Exception($"Error on delete: Status code: {result.StatusCode}");
        }
    }

    public async Task<ICollection<EstimationImportSettings>> GetAllAsync()
    {
        return await GetAsync<ICollection<EstimationImportSettings>>("/api/import/GetAllImportSettings");
    }

    public async Task<EstimationImportSettings> GetStandardAsync()
    {
        return await GetAsync<EstimationImportSettings>("/api/import/GetStandardImportSettings");
    }

    public async Task UpsertAsync(EstimationImportSettings settings)
    {
        var client = _httpClientFactory.CreateClient(AppConstants.BackendHttpClientName);
        var result = await client.PostAsJsonAsync("/api/import/UpsertImportSettings", settings);
        if (!result.IsSuccessStatusCode)
        {
            throw new Exception(result.ReasonPhrase);
        }
    }
    private async Task<T> GetAsync<T>(string requestUri)
    {
        var client = _httpClientFactory.CreateClient(AppConstants.BackendHttpClientName);
        var result = await client.GetAsync(requestUri);
        if (result.IsSuccessStatusCode)
        {
            var content = await result.Content.ReadFromJsonAsync<T>();
            return content!;
        }
        else
        {
            throw new Exception(result.ReasonPhrase);
        }
    }
}
