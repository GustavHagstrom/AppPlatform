using BidConReport.Shared.Models;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Logic;

public class BidConImporter : IBidConImporter
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BidConImporter(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<BidConImportResult<DbFolder>> GetFoldersAsync()
    {
        var result = await GetHttpClient().GetAsync("bidcon/getfolders");
        result.EnsureSuccessStatusCode();
        return (await result.Content.ReadFromJsonAsync<BidConImportResult<DbFolder>>())!;
    }
    public async Task<BidConImportResult<IEnumerable<DbEstimation>>> GetEstimationsAsync()
    {
        var result = await GetHttpClient().GetAsync("bidcon/getestimations");
        result.EnsureSuccessStatusCode();
        return (await result.Content.ReadFromJsonAsync<BidConImportResult<IEnumerable<DbEstimation>>>())!;
    }
    public async Task<BidConImportResult<SimpleEstimation>> GetEstimationAsync(string id, EstimationImportSettings settings)
    {
        var result = await GetHttpClient().PostAsJsonAsync("bidcon/getfolders", settings);
        result.EnsureSuccessStatusCode();
        return (await result.Content.ReadFromJsonAsync<BidConImportResult<SimpleEstimation>>())!;
    }
    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient(Constants.BidConApiHttpClientName);
    }

}