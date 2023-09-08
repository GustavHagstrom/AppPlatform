using BidConReport.Client.Shared.Constants;
using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs.BidconAccess;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Import.Services;

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
    public async Task<IEnumerable<BC_EstimationDto>?> GetListAsync(BC_DatabaseCredentialsDto databaseCredentials, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetEstimationList, databaseCredentials, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<BC_EstimationDto>>();
    }
    public async Task<BC_EstimationFolderBatch?> GetFolderBatchAsync(BC_DatabaseCredentialsDto databaseCredentials, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient(HttpClientNames.BidconLink);
        var response = await client.PostAsJsonAsync(BidconLinkEndpoints.GetFolderBatch, databaseCredentials, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BC_EstimationFolderBatch>();
    }
}
