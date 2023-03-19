namespace BidConReport.Shared.Features.ReportLayout.GeneralInformation;
public class GeneralInformationSection : ILayoutSection
{
    public bool IsEnabled { get; set; } = true;
    public List<GeneralInformationItem> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public FontProperties TitleFont { get; set; } = DefaultTitleFont();
    public FontProperties ValueFont { get; set; } = DefaultValueFont();
    public static GeneralInformationSection Default => new()
    {
        Items = new List<GeneralInformationItem>
        {
            new(true, GeneralInformationType.Name, "Name"),
            new(true, GeneralInformationType.Description, "Description"),
            new(true, GeneralInformationType.CreationDate, "Creation date"),
            new(true, GeneralInformationType.ExpirationDate, "Expiration date"),
            new(true, GeneralInformationType.PrintDate, "Print date"),
            new(true, GeneralInformationType.Supervisor, "Supervisor"),
            new(true, GeneralInformationType.Representative, "Representative"),
            new(true, GeneralInformationType.Currency, "Currency"),
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
public record GeneralInformationItem(bool IsEnabled, GeneralInformationType Type, string Title);
public enum GeneralInformationType
{
    Name,
    Description,
    CreationDate,
    ExpirationDate,
    PrintDate,
    Supervisor,
    Representative,
    Currency,
}