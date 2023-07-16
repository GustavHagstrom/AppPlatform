using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate;
public class FontProperties
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string FontName { get; set; }
    public int FontSize { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }

    public static FontProperties Default => new()
    {
        FontName = "Calibri",
        FontSize = 11,
        Bold = false,
        Italic = false,
        Underline = false,
    };
}
