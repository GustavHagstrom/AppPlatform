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
        try
        {
            var result = await GetHttpClient().GetAsync("bidcon/getfolders");
            result.EnsureSuccessStatusCode();
            return (await result.Content.ReadFromJsonAsync<BidConImportResult<DbFolder>>())!;
        }
        catch (HttpRequestException)
        {
            return new BidConImportResult<DbFolder> { ErrorMessage = "Failed to connect to the Bidcon link" };
        }
        catch (Exception e)
        {
            return new BidConImportResult<DbFolder> { ErrorMessage= e.Message };
        }
    }
    public async Task<BidConImportResult<Estimation>> GetEstimationAsync(string id, EstimationImportSettings settings)
    {
        
        try
        {
            var result = await GetHttpClient().PostAsJsonAsync($"bidcon/getestimation/{id}", settings);
            result.EnsureSuccessStatusCode();
            return (await result.Content.ReadFromJsonAsync<BidConImportResult<Estimation>>())!;
        }
        catch (HttpRequestException)
        {
            return new BidConImportResult<Estimation> { ErrorMessage = "Failed to connect to the Bidcon link" };
        }
        catch (Exception e)
        {
            return new BidConImportResult<Estimation> { ErrorMessage = e.Message };
        }
    }
    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient(Constants.BidConApiHttpClientName);
    }

}