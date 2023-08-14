using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class InformationSectionDTO : IReportTemplateSectionDTO
{
    public int Id { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<InformationItemDTO> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public int TitleFontId { get; set; }
    public FontPropertiesDTO TitleFont { get; set; } = DefaultTitleFont();
    public int ValueFontId { get; set; }
    public FontPropertiesDTO ValueFont { get; set; } = DefaultValueFont();

    public static InformationSectionDTO Default => new()
    {
        LayoutOrder = 2,
    };
    private static FontPropertiesDTO DefaultTitleFont()
    {
        var font = FontPropertiesDTO.Default;
        font.Bold = true;
        font.FontSize = 11;
        return font;
    }
    private static FontPropertiesDTO DefaultValueFont()
    {
        var font = FontPropertiesDTO.Default;
        font.FontSize = 11;
        return font;
    }
}
