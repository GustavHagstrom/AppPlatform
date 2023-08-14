using BidConReport.Server.Enteties.Report;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Server.Services.Report;
public interface IReportTemplatesService
{
    Task DeleteAsync(int templateId, string userId, string organizationId);
    Task<ICollection<ReportTemplate>> GetAllOrganizationTemplatesAsync(string organizationId);
    Task<ReportTemplate?> GetDefaultAsync(string userId, string organizationId);
    Task UpsertAsync(string userId, string organizationId, ReportTemplate reportTemplate);
    Task SetAsDefaultAsync(string userId, string organizationId, int templateId);
}