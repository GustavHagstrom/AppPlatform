using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Shared.Constants;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconLinkService : IBidconLinkService
{
    IHttpClientFactory _httpClientFactory;

    public BidconLinkService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<D_EstimationBatch?> GetBatchAsync(D_EstimationRequestBatchModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<D_EstimationBatch>();
    }
    public async Task<IEnumerable<D_EstimationBatch>?> GetManyBatchesAsync(D_EstimationRequestBatchesModel request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<D_EstimationBatch>>();
        return batches;
    }
    public async Task<IEnumerable<D_Estimation>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<D_Estimation>>();
    }
    public async Task<D_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<D_EstimationFolderBatch>();
    }
}
