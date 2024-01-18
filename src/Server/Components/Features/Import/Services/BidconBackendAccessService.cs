using AppPlatform.Core.Constants;
using AppPlatform.Core.DTOs.BidconAccess;
using AppPlatform.Shared.Wrappers;

namespace AppPlatform.Server.Components.Features.Import.Services;

public class BidconBackendAccessService : IBidconBackendAccessService
{
    private readonly IHttpClientWrapper _httpClient;

    public BidconBackendAccessService(IHttpClientWrapper httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<BC_EstimationBatchDto?> GetBatchAsync(EstimationRequestBatchModelDto request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationBatchDto>();
    }
    public async Task<IEnumerable<BC_EstimationBatchDto>?> GetManyBatchesAsync(EstimationRequestBatchesModelDto request, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationBatchDto>>();
        return batches;
    }
    public async Task<IEnumerable<BC_EstimationDto>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationDto>>();
    }
    public async Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationFolderBatch>();
    }
}
