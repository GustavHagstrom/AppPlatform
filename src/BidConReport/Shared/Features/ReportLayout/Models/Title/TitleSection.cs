
namespace BidConReport.Shared.Features.ReportLayout.Models.Title;
public class TitleSection : ILayoutSection
{
    public int LayoutOrder { get; set; }
    public string Title { get; set; } = string.Empty;
    public FontProperties Font { get; set; } = FontProperties.Default;
    public string Image { get; set; } = string.Empty;
}
