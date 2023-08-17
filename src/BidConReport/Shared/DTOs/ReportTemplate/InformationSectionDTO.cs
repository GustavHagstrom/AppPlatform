using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class InformationSectionDto : IReportTemplateSectionDTO
{
    public int Id { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<InformationItemDTO> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public int TitleFontId { get; set; }
    public FontPropertiesDto TitleFont { get; set; } = DefaultTitleFont();
    public int ValueFontId { get; set; }
    public FontPropertiesDto ValueFont { get; set; } = DefaultValueFont();

    public static InformationSectionDto Default => new()
    {
        LayoutOrder = 2,
    };
    private static FontPropertiesDto DefaultTitleFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = true;
        font.FontSize = 11;
        return font;
    }
    private static FontPropertiesDto DefaultValueFont()
    {
        var font = FontPropertiesDto.Default;
        font.FontSize = 11;
        return font;
    }
}
