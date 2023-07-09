using BidConReport.Shared.Features.ReportTemplate;

namespace BidConReport.Client.Shared.Services;
public interface IReportTemplateCrudService
{
    Task Create(ReportTemplate reportTemplate);
    void Delete(int id);
    Task<ReportTemplate> Get(int id);
    Task<ICollection<ReportTemplate>> GetAll();
    Task<ReportTemplate?> GetDefault();
    Task SetAsDefault(int id);
    Task Update(ReportTemplate reportTemplate);
}