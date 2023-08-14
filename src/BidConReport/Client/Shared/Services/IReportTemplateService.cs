using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Client.Shared.Services;
public interface IReportTemplateService
{
    Task UpsertAsync(ReportTemplateDTO reportTemplate);
    Task DeleteAsync(int id);
    Task<ICollection<ReportTemplateDTO>> GetAllAsync();
    Task<ReportTemplateDTO?> GetDefaultAsync();
    Task SetAsDefaultAsync(ReportTemplateDTO? reportTemplate);
}