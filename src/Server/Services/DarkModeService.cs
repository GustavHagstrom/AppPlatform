using SharedLibrary.Constants;
using SharedLibrary.Wrappers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Server.Services;

public class DarkModeService : IDarkModeService
{
    private readonly IHttpClientWrapper _httpClient;
    private readonly ILogger<IDarkModeService> _logger;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public DarkModeService(IHttpClientWrapper httpClient, ILogger<IDarkModeService> logger, AuthenticationStateProvider authenticationStateProvider)
    {
        _httpClient = httpClient;
        _logger = logger;
        _authenticationStateProvider = authenticationStateProvider;
    }
    public async Task<bool> GetUserDarkModeSettingAsync()
    {
        try
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (authState.User.Identity is not null && authState.User.Identity.IsAuthenticated)
            {
                var result = await _httpClient.GetAsync(BackendApiEndpoints.DarkModeController.Get);
                if (result.IsSuccessStatusCode)
                {
                    var boolString = await result.Content.ReadAsStringAsync();
                    return bool.Parse(boolString);
                }
            }
            return false;
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
