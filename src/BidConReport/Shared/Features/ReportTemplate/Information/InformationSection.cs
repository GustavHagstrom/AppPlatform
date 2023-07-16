namespace BidConReport.Shared.Features.ReportTemplate.Information;
public class InformationSection : IReportTemplateSection
{
    public int Id { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<InformationItem> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public int TitleFontId { get; set; }
    public FontProperties? TitleFont { get; set; } = DefaultTitleFont();
    public int ValueFontId { get; set; }
    public FontProperties? ValueFont { get; set; } = DefaultValueFont();
    public static InformationSection Default => new()
    {
        Items = new List<InformationItem>
        {
            new(true, InformationType.Name, "Name"),
            new(true, InformationType.Description, "Description"),
            new(true, InformationType.CreationDate, "Creation date"),
            new(true, InformationType.ExpirationDate, "Expiration date"),
            new(true, InformationType.PrintDate, "Print date"),
            new(true, InformationType.Supervisor, "Supervisor"),
            new(true, InformationType.Representative, "Representative"),
            new(true, InformationType.Currency, "Currency"),
        },
    };
    private static FontProperties DefaultTitleFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 11;
        return font;
    }
    private static FontProperties DefaultValueFont()
    {
        var font = FontProperties.Default;
        font.FontSize = 11;
        return font;
    }
}
