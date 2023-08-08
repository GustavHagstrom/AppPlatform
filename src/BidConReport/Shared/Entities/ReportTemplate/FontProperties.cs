using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Entities.ReportTemplate;
public class FontProperties
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string FontFamily { get; set; }
    [Range(1,200)]
    public int FontSize { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }

    public static FontProperties Default => new()
    {
        FontFamily = "Calibri",
        FontSize = 11,
        Bold = false,
        Italic = false,
        Underline = false,
    };
}
