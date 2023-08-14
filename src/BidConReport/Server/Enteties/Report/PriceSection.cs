using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties.Report;
public class PriceSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; }
    public bool ShowChanges { get; set; }
    [MaxLength(50)]
    public string? PriceWithoutChangesDescription { get; set; }
    [MaxLength(50)]
    public string? ChangesDescription { get; set; }
    [MaxLength(50)]
    public string? PriceWithChangesDescription { get; set; }
    [MaxLength(50)]
    public string? Comment { get; set; }
    public int PriceFontId { get; set; }
    public required FontProperties PriceFont { get; set; }
    public int CommentFontId { get; set; }
    public required FontProperties CommentFont { get; set; }
}
