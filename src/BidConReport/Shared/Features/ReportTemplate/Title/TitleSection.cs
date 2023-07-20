using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate.Title;
public class TitleSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = "Title";
    public FontProperties Font { get; set; } = DefaultFont();
    public string Image { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;

    private static FontProperties DefaultFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 30;
        return font;
    }
}
