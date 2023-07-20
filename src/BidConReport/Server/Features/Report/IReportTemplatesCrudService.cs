using BidConReport.Shared.Features.ReportTemplate;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BidConReport.Server.Features.Report;
public interface IReportTemplatesCrudService
{
    Task DeleteAsync(int templateId, string userId);
    Task<ICollection<ReportTemplate>> GetAllOrganizationTemplatesAsync(string organizationId);
    Task<ReportTemplate?> GetDefaultAsync(string userId);
    Task UpsertAsync(ReportTemplate reportTemplate);
    Task SetAsDefaultAsync(string userId, int templateId);
}