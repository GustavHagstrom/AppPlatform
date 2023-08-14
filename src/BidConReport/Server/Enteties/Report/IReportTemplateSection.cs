namespace BidConReport.Server.Enteties.Report;
public interface IReportTemplateSection
{
    int LayoutOrder { get; set; }
    bool IsEnabled { get; set; }
}
