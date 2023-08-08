namespace BidConReport.Shared.Entities.ReportTemplate;
public interface IReportTemplateSection
{
    int LayoutOrder { get; set; }
    bool IsEnabled { get; set; }
}
