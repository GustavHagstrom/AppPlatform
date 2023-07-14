using BidConReport.Shared.Features.ReportTemplate;

namespace BidConReport.Server.Features.Report;

public class ReportTemplatesCrudService
{
    public async Task UpsertAsync(ReportTemplate reportTemplate)
    {
        throw new NotImplementedException();
    }
    public async Task<ICollection<ReportTemplate>> GetAllOrganizationTemplatesAsync(string organizationId)
    {
        throw new NotImplementedException();
    }
    public async Task<ReportTemplate> GetDefaultAsync(string userId)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAsync(string templateId, string userId)
    {
        throw new NotImplementedException();
    }
}
