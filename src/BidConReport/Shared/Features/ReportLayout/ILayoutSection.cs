namespace BidConReport.Shared.Features.ReportLayout;
public interface ILayoutSection
{
    int LayoutOrder { get; set; }
    bool IsEnabled { get; set; }
}
