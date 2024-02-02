using AppPlatform.BidconDataAccess.Models;
using AppPlatform.Client.Shared.Constants;
using AppPlatform.Core.Constants;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconLinkService : IBidconLinkService
{
    IHttpClientFactory _httpClientFactory;

    public BidconLinkService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<BC_EstimationBatch?> GetBatchAsync(EstimationRequestBatchModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationBatch>();
    }
    public async Task<IEnumerable<BC_EstimationBatch>?> GetManyBatchesAsync(EstimationRequestBatchesModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationBatch>>();
        return batches;
    }
    public async Task<IEnumerable<BC_Estimation>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<BC_Estimation>>();
    }
    public async Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationFolderBatch>();
    }
}
