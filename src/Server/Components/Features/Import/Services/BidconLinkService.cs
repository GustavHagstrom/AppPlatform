using AppPlatform.BidconDataAccess.Models;
using AppPlatform.Core.Constants;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconLinkService : IBidconLinkService
{
    IHttpClientFactory _httpClientFactory;

    public BidconLinkService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<EstimationBatch?> GetBatchAsync(EstimationRequestBatchModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EstimationBatch>();
    }
    public async Task<IEnumerable<EstimationBatch>?> GetManyBatchesAsync(EstimationRequestBatchesModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<EstimationBatch>>();
        return batches;
    }
    public async Task<IEnumerable<Estimation>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Estimation>>();
    }
    public async Task<EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EstimationFolderBatch>();
    }
}
