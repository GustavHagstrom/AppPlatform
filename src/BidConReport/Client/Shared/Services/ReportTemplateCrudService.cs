using BidConReport.Shared.Constants;
using BidConReport.Shared.Features.ReportTemplate;
using SharedPlatformLibrary.Wrappers;
using System.Net.Http.Json;

namespace BidConReport.Client.Shared.Services;

public class ReportTemplateCrudService : IReportTemplateCrudService
{
    private readonly IHttpClientWrapper _httpClient;

    public ReportTemplateCrudService(IHttpClientWrapper httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task UpsertAsync(ReportTemplate reportTemplate)
    {
        var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.ReportTemplatesController.Upsert, reportTemplate);
        response.EnsureSuccessStatusCode();
    }
    public async Task<ICollection<ReportTemplate>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync(BackendApiEndpoints.ReportTemplatesController.All);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadFromJsonAsync<ICollection<ReportTemplate>>();
        return data ?? Array.Empty<ReportTemplate>();
    }
    public async Task<ReportTemplate?> GetDefaultAsync()
    {
        var response = await _httpClient.GetAsync(BackendApiEndpoints.ReportTemplatesController.Default);
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadFromJsonAsync<ReportTemplate>();
        return data;
    }
    public async Task SetAsDefaultAsync(ReportTemplate reportTemplate)
    {
        var response = await _httpClient.PostAsJsonAsync(BackendApiEndpoints.ReportTemplatesController.SetDefault, reportTemplate);
        response.EnsureSuccessStatusCode();
    }
    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync(BackendApiEndpoints.ReportTemplatesController.Delete + id.ToString());
        response.EnsureSuccessStatusCode();
    }

}
