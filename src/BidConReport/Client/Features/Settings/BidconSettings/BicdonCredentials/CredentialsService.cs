using BidConReport.Shared.Constants;
using BidConReport.Shared.DTOs.BidconAccess;
using SharedPlatformLibrary.Wrappers;
using System.Net;
using System.Net.Http.Json;

namespace BidConReport.Client.Features.Settings.BidconSettings.BicdonCredentials;

public class CredentialsService : ICredentialsService
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<ICredentialsService> _logger;

    public CredentialsService(IHttpClientWrapper httpClient, ILogger<ICredentialsService> logger)
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
