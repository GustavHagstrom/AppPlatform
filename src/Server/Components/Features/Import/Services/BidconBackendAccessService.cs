using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Shared.Constants;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconBackendAccessService : IBidconBackendAccessService
{
    private readonly HttpClient _httpClient;

    public BidconBackendAccessService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<D_EstimationBatch?> GetBatchAsync(D_EstimationRequestBatchModel request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<D_EstimationBatch>();
    }
    public async Task<IEnumerable<D_EstimationBatch>?> GetManyBatchesAsync(D_EstimationRequestBatchesModel request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<D_EstimationBatch>>();
        return batches;
    }
    public async Task<IEnumerable<D_Estimation>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<D_Estimation>>();
    }
    public async Task<D_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<D_EstimationFolderBatch>();
    }
}
