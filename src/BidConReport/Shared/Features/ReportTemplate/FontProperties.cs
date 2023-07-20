using BidConReport.Shared.Features.ReportTemplate.Header;
using BidConReport.Shared.Features.ReportTemplate.Information;
using BidConReport.Shared.Features.ReportTemplate.Price;
using BidConReport.Shared.Features.ReportTemplate.Table;
using BidConReport.Shared.Features.ReportTemplate.Title;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate;
public class FontProperties
{
    public int Id { get; set; }
    public int FontFamilyId { get; set; }
    public FontFamily? FontFamily { get; set; }
    public int FontSize { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }

    public static FontProperties Default => new()
    {
        FontFamily = new  FontFamily { Value = "Calibri" },
        FontSize = 11,
        Bold = false,
        Italic = false,
        Underline = false,
    };
}
