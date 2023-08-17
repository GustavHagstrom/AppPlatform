using BidConReport.Server.Enteties.Report;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Server.Services.Report;
public interface IReportTemplatesService
{
    Task DeleteAsync(int templateId, string userId, string organizationId);
    Task<ICollection<ReportTemplateDto>> GetAllOrganizationTemplatesAsync(string organizationId);
    Task<ReportTemplateDto?> GetDefaultAsync(string userId, string organizationId);
    Task UpsertAsync(string userId, string organizationId, ReportTemplateDto dto);
    Task SetAsDefaultAsync(string userId, string organizationId, int templateId);
}