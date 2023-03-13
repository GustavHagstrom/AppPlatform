using BidConReport.Shared;
using BidConReport.Shared.Models;
using System;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Services;

public class BidConImporterService : IBidConImporterService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BidConImporterService(IHttpClientFactory httpClientFactory)
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
        return _httpClientFactory.CreateClient(AppConstants.BidConApiHttpClientName);
    }

    public async Task<IEnumerable<BidConImportResult<Estimation>>> GetEstimationsAsync(IEnumerable<string> ids, EstimationImportSettings settings, IProgress<BidConImportResult<Estimation>>? progress = null)
    {
        var batchSize = 1;
        var semaphore = new SemaphoreSlim(batchSize);

        var count = 1;
        var tasks = new List<Task<BidConImportResult<Estimation>>>();
        foreach (var id in ids) 
        {
            await semaphore.WaitAsync();
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    var result = await GetEstimationAsync(id, settings);
                    progress?.Report(result);
                    //var percentComplete = count * 100 / ids.Count();
                    //progress?.Report(percentComplete);
                    return result;
                }
                finally
                {
                    semaphore.Release();
                }
            }));

            count += 1;
        }

        return await Task.WhenAll(tasks);
    }
}