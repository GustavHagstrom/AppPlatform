using SharedLibrary.Models;
using System.Net.Http.Json;

namespace ApiAccessLibrary.ApiHandlers;
public class AuthenticationApiHandler : IAuthenticationApiHandler
{
    private readonly HttpClient _httpClient;
    private const string Controller = "Authentication";

    public AuthenticationApiHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<TokenModel> LoginAsync(LoginModel loginModel)
    {
        var url = $"/{Controller}/login";
        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, loginModel);
            if (response.IsSuccessStatusCode)
            {
                return (await response.Content.ReadFromJsonAsync<TokenModel>())!;
            }
            throw new Exception($"HttpError\nStatusCode: {response.StatusCode}\nResonPhrase: {response.ReasonPhrase}\nUrl: {url}");
        }
        catch (Exception e)
        {
            throw new Exception(url, e);
        }

    }
    public async Task<TokenModel> RefreshTokenAsync(TokenModel tokenModel)
    {
        var url = $"/{Controller}/activate-refreshtoken";
        var response = await _httpClient.PostAsJsonAsync(url, tokenModel);
        if (response.IsSuccessStatusCode)
        {
            return (await response.Content.ReadFromJsonAsync<TokenModel>())!;
        }
        throw new Exception($"HttpError\nStatusCode: {response.StatusCode}\nResonPhrase: {response.ReasonPhrase}\nUrl: {url}");
    }
}
