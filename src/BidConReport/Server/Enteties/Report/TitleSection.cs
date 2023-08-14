using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties.Report;
public class TitleSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    [MaxLength(50)]
    public string? Title { get; set; }
    public required FontProperties Font { get; set; }
    public string? Image { get; set; }
    public bool IsEnabled { get; set; }

}
