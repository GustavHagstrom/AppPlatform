using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class TitleSectionDto : IReportTemplateSectionDTO
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    public FontPropertiesDto Font { get; set; } = DefaultFont();
    public string Image { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;

    private static FontPropertiesDto DefaultFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = true;
        font.FontSize = 30;
        return font;
    }
}
