namespace BidConReport.Server.Enteties.ReportTemplate;
public interface IReportTemplateSection
{
    int LayoutOrder { get; set; }
    bool IsEnabled { get; set; }
}
