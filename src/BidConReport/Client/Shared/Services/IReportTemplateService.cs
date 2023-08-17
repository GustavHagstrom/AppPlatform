using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Client.Shared.Services;
public interface IReportTemplateService
{
    Task UpsertAsync(ReportTemplateDto reportTemplate);
    Task DeleteAsync(int id);
    Task<ICollection<ReportTemplateDto>> GetAllAsync();
    Task<ReportTemplateDto?> GetDefaultAsync();
    Task SetAsDefaultAsync(ReportTemplateDto? reportTemplate);
}