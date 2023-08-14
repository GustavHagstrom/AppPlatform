namespace BidConReport.Server.Enteties.ReportTemplate;
public class InformationSection : IReportTemplateSection
{
    public int Id { get; set; }
    public bool IsEnabled { get; set; } = true;
    public required List<InformationItem> Items { get; set; }
    public int LayoutOrder { get; set; }
    public int TitleFontId { get; set; }
    public required FontProperties TitleFont { get; set; }
    public int ValueFontId { get; set; }
    public required FontProperties ValueFont { get; set; }
}
