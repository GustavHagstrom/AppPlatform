using BidConReport.Server.Enteties.Report;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Server.Services.Report;
public interface IReportTemplatesService
{
    Task DeleteAsync(int templateId, string userId, int organizationId);
    Task<ICollection<ReportTemplateDto>> GetAllOrganizationTemplatesAsync(int organizationId);
    Task<ReportTemplateDto?> GetDefaultAsync(string userId, int organizationId);
    Task UpsertAsync(string userId, int organizationId, ReportTemplateDto dto);
    Task SetAsDefaultAsync(string userId, int organizationId, int templateId);
}