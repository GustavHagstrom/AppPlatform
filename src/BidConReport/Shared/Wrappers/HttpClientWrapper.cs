using System.Net.Http.Json;

namespace BidConReport.Shared.Wrappers;
public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient;

    public HttpClientWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetAsync(requestUri, cancellationToken);
    }

    public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAsync(requestUri, content, cancellationToken);
    }

    public async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PutAsync(requestUri, content, cancellationToken);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken = default)
    {
        return await _httpClient.DeleteAsync(requestUri, cancellationToken);
    }
    public async Task<T?> GetFromJsonAsync<T>(string requestUri, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<T>(requestUri, cancellationToken);
    }
    public async Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T data, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PostAsJsonAsync(requestUri, data, cancellationToken);
    }

    public async Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T data, CancellationToken cancellationToken = default)
    {
        return await _httpClient.PutAsJsonAsync(requestUri, data, cancellationToken);
    }
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
