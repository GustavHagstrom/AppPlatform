using Client.Shared.Constants;
using SharedLibrary.Constants;
using SharedLibrary.DTOs.BidconAccess;
using System.Net.Http.Json;

namespace Server.Components.Features.Import.Services;

public class BidconLinkService : IBidconLinkService
{
    IHttpClientFactory _httpClientFactory;

    public BidconLinkService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<BC_EstimationBatchDto?> GetBatchAsync(EstimationRequestBatchModelDto request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatch, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationBatchDto>();
    }
    public async Task<IEnumerable<BC_EstimationBatchDto>?> GetManyBatchesAsync(EstimationRequestBatchesModelDto request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationBatches, request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var batches = await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationBatchDto>>();
        return batches;
    }
    public async Task<IEnumerable<BC_EstimationDto>?> GetListAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetEstimationList, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationDto>>();
    }
    public async Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.GetAsync(BidconLinkEndpoints.GetFolderBatch, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationFolderBatch>();
    }
}
