using BidConReport.Server.Enteties.ReportTemplate;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Server.Features.Report;
public interface IReportTemplatesCrudService
{
    Task DeleteAsync(int templateId, string userId, string organizationId);
    Task<ICollection<ReportTemplate>> GetAllOrganizationTemplatesAsync(string organizationId);
    Task<ReportTemplate?> GetDefaultAsync(string userId, string organizationId);
    Task UpsertAsync(string userId, string organizationId, ReportTemplate reportTemplate);
    Task SetAsDefaultAsync(string userId, string organizationId, int templateId);
}