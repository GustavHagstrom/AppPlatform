using BidConReport.Shared.Features.ReportTemplate;

namespace BidConReport.Client.Shared.Services;
public interface IReportTemplateCrudService
{
    Task UpsertAsync(ReportTemplate reportTemplate);
    Task DeleteAsync(int id);
    Task<ICollection<ReportTemplate>> GetAllAsync();
    Task<ReportTemplate?> GetDefaultAsync();
    Task SetAsDefaultAsync(ReportTemplate reportTemplate);
}