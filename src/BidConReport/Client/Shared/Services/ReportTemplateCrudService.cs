using BidConReport.Shared.Features.ReportTemplate;

namespace BidConReport.Client.Shared.Services;

public class ReportTemplateCrudService : IReportTemplateCrudService
{
    private readonly HttpClient _httpClient;

    public ReportTemplateCrudService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task Create(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
    public async Task<ICollection<ReportTemplate>> GetAll()
    {
        throw new NotImplementedException();
    }
    public async Task<ReportTemplate> Get(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<ReportTemplate?> GetDefault()
    {
        throw new NotImplementedException();
    }
    public async Task SetAsDefault(int id)
    {
        throw new NotImplementedException();
    }
    public async Task Update(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}
