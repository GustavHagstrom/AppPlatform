using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportLayout.Price;
public class PriceSection : ILayoutSection
{
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    [MaxLength(50)]
    public string PriceWithoutChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string PriceWithChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Comment { get; set; } = string.Empty;
    public FontProperties PriceFont { get; set; } = FontProperties.Default;
    public FontProperties CommentFont { get; set; } = FontProperties.Default;
}
