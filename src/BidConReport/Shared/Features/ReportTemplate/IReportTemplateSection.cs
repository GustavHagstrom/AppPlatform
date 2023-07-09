namespace BidConReport.Shared.Features.ReportTemplate;
public interface IReportTemplateSection
{
    int LayoutOrder { get; set; }
    bool IsEnabled { get; set; }
}
