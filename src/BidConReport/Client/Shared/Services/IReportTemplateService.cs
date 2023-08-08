using BidConReport.Shared.Entities.ReportTemplate;

namespace BidConReport.Client.Shared.Services;
public interface IReportTemplateService
{
    Task UpsertAsync(ReportTemplate reportTemplate);
    Task DeleteAsync(int id);
    Task<ICollection<ReportTemplate>> GetAllAsync();
    Task<ReportTemplate?> GetDefaultAsync();
    Task SetAsDefaultAsync(ReportTemplate? reportTemplate);
}