using ApiAccessLibrary.Estimation;
using SharedLibrary.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiAccessLibrary.ApiHandlers;
public class BidconApiHandler : IBidconApiHandler
{
    private readonly HttpClient _httpClient;
    private const string CONTROLLER = "Bidcon";

    public BidconApiHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<DbFolder> GetFolderAsync(TokenModel tokenModel)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.Token);
        var url = $"/{CONTROLLER}/GetFolders";
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<DbFolder>();
            return result!;
        }
        else
        {
            throw new Exception($"HttpError\nStatusCode: {response.StatusCode}\nResonPhrase: {response.ReasonPhrase}");
        }
    }
    public async Task<IEnumerable<DbEstimation>> GetEstimationsAsync(TokenModel tokenModel)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.Token);
        var url = $"/{CONTROLLER}/GetEstimations";
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<DbEstimation>>();
            return result!;
        }
        else
        {
            throw new Exception($"HttpError\nStatusCode: {response.StatusCode}\nResonPhrase: {response.ReasonPhrase}");
        }
    }
    public async Task<SimpleEstimation> GetEstimationAsync(TokenModel tokenModel, string id, EstimationImportSettings settings)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenModel.Token);
        var url = $"/{CONTROLLER}/GetEstimation/{id}";
        var response = await _httpClient.PostAsJsonAsync(url, settings);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<SimpleEstimation>();
            EstimationPostApiFixer.FixParentReferences(result!);
            return result!;
        }
        else
        {
            throw new Exception($"HttpError\nStatusCode: {response.StatusCode}\nResonPhrase: {response.ReasonPhrase}");
        }
    }

}
