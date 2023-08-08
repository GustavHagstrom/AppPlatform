using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Entities.ReportTemplate;

namespace BidConReport.Shared.Entities.ReportTemplate.Information;
public class InformationSection : IReportTemplateSection
{
    public int Id { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<InformationItem> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public int TitleFontId { get; set; }
    public FontProperties TitleFont { get; set; } = DefaultTitleFont();
    public int ValueFontId { get; set; }
    public FontProperties ValueFont { get; set; } = DefaultValueFont();

    public static InformationSection Default => new()
    {
        LayoutOrder = 2,
    };
    private static FontProperties DefaultTitleFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 11;
        return font;
    }
    private static FontProperties DefaultValueFont()
    {
        var font = FontProperties.Default;
        font.FontSize = 11;
        return font;
    }
}
