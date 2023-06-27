namespace BidConReport.Shared.Features.ReportLayout.Title;
public class TitleSection : ILayoutSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public string Title { get; set; } = "Title";
    public FontProperties Font { get; set; } = DefaultFont();
    public string Image { get; set; } = string.Empty;
    public bool IsEnabled { get; set; } = true;

    private static FontProperties DefaultFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 30;
        return font;
    }
}
