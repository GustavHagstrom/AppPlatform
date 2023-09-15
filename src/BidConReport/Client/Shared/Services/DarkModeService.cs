using BidConReport.Shared.Constants;
using BidConReport.Shared.Wrappers;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services;

public class DarkModeService : IDarkModeService
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<IDarkModeService> _logger;

    public DarkModeService(IHttpClientWrapper httpClient, ILogger<IDarkModeService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    public async Task<bool> GetUserDarkModeSettingAsync()
    {
        try
        {
            var result = await _httpClient.GetAsync(BackendApiEndpoints.DarkModeController.Get);
            result.EnsureSuccessStatusCode();
            var boolString = await result.Content.ReadAsStringAsync();
            return bool.Parse(boolString);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when sending darkmode get request");
            return false;
        }
    }
    public async Task SetUserDarkModeSettingAsync(bool isDarkMode)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync(BackendApiEndpoints.DarkModeController.Put, isDarkMode.ToString());
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when sending darkmode put request");
            throw;
        }
    }
}
