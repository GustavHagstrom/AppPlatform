using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate.Price;
public class PriceSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool ShowChanges { get; set; } = true;
    [MaxLength(50)]
    public string PriceWithoutChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string PriceWithChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Comment { get; set; } = string.Empty;
    public int PriceFontId { get; set; }
    public FontProperties PriceFont { get; set; } = FontProperties.Default;
    public int CommentFontId { get; set; }
    public FontProperties CommentFont { get; set; } = FontProperties.Default;
}
