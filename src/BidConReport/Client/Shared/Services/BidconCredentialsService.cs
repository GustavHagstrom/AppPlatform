using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs.BidconAccess;
using BidConReport.Shared.Wrappers;
using System.Net;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services;

public class BidconCredentialsService : IBidconCredentialsService
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<IBidconCredentialsService> _logger;

    public BidconCredentialsService(IHttpClientWrapper httpClient, ILogger<IBidconCredentialsService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task<BC_DatabaseCredentialsDto?> GetAsync()
    {
        var response = await _httpClient.GetAsync(BackendApiEndpoints.BidconCredentialsController.Get);
        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<BC_DatabaseCredentialsDto>();
        return result;

    }
    public async Task UpsertAsync(BC_DatabaseCredentialsDto credentials)
    {
        await _httpClient.PostAsJsonAsync(BackendApiEndpoints.BidconCredentialsController.Upsert, credentials);
    }
}
