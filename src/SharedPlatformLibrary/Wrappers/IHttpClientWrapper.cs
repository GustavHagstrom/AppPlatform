namespace SharedPlatformLibrary.Wrappers;

public interface IHttpClientWrapper : IDisposable
{
    Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken = default);
    Task<T?> GetFromJsonAsync<T>(string requestUri, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T data, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T data, CancellationToken cancellationToken = default);
    Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken = default);
}