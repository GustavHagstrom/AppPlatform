using AppPlatform.BidconDataAccess.Models;
using AppPlatform.Core.Constants;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconBackendAccessService : IBidconBackendAccessService
{
    private readonly HttpClient _httpClient;

    public BidconBackendAccessService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<BC_EstimationBatch?> GetBatchAsync(EstimationRequestBatchModel request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationBatch>();
    }
    public async Task<IEnumerable<BC_EstimationBatch>?> GetManyBatchesAsync(EstimationRequestBatchesModel request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationBatch>>();
        return batches;
    }
    public async Task<IEnumerable<BC_Estimation>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<BC_Estimation>>();
    }
    public async Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationFolderBatch>();
    }
}
