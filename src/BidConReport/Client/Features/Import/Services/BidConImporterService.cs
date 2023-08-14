using BidConReport.Client.Shared.Constants;
using BidConReport.Client.Shared.Services;
using BidConReport.Shared.DTOs;
using BidConReport.Shared.DTOs;
using System;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Services;

public class BidConImporterService : IBidConImporterService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IEstimationParentReferencer _parentReferencer;

    public BidConImporterService(IHttpClientFactory httpClientFactory, IEstimationParentReferencer parentReferencer)
    {
        _httpClientFactory = httpClientFactory;
        _parentReferencer = parentReferencer;
    }
    public async Task<BidConImportResultDTO<DbFolderDTO>> GetFoldersAsync()
    {
        try
        {
            var result = await GetHttpClient().GetAsync("bidcon/getfolders");
            result.EnsureSuccessStatusCode();
            return (await result.Content.ReadFromJsonAsync<BidConImportResultDTO<DbFolderDTO>>())!;
        }
        catch (HttpRequestException)
        {
            return new BidConImportResultDTO<DbFolderDTO> { ErrorMessage = "Failed to connect to the Bidcon link" };
        }
        catch (Exception e)
        {
            return new BidConImportResultDTO<DbFolderDTO> { ErrorMessage= e.Message };
        }
    }
    public async Task<BidConImportResultDTO<EstimationDTO>> GetEstimationAsync(BidconImportRequestDTO request, CancellationToken cancelToken)
    {
        
        try
        {
            var result = await GetHttpClient().PostAsJsonAsync($"bidcon/getestimation", request, cancelToken);
            result.EnsureSuccessStatusCode();
            var importResult = (await result.Content.ReadFromJsonAsync<BidConImportResultDTO<EstimationDTO>>())!;
            if (importResult.Value is not null)
            {
                _parentReferencer.SetAllParentReferences(importResult.Value);
            }
            return importResult;
        }
        catch (HttpRequestException)
        {
            return new BidConImportResultDTO<EstimationDTO> { ErrorMessage = "Failed to connect to the Bidcon link" };
        }
        catch (Exception e)
        {
            return new BidConImportResultDTO<EstimationDTO> { ErrorMessage = e.Message };
        }
    }

    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient(HttpClientNames.DesktopBridgeAddress);
    }

    public async Task<IEnumerable<BidConImportResultDTO<EstimationDTO>>> GetEstimationsAsync(IEnumerable<DbEstimationDTO> estimations, EstimationImportSettingsDTO settings, CancellationToken cancelToken, IProgress<BidConImportResultDTO<EstimationDTO>>? progress = null)
    {
        var batchSize = 1;
        var semaphore = new SemaphoreSlim(batchSize);

        var count = 1;
        var tasks = new List<Task<BidConImportResultDTO<EstimationDTO>>>();
        foreach (var estimation in estimations) 
        {
            await semaphore.WaitAsync();
            tasks.Add(Task.Run(async () =>
            {
                try
                {
                    var result = await GetEstimationAsync(new BidconImportRequestDTO { Estimation = estimation, Settings = settings}, cancelToken);
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