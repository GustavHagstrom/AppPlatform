namespace BidConReport.Shared.Features.ReportLayout.Models.GeneralInformation;
public class GeneralInformationSection : ILayoutSection
{
    public bool IsEnabled { get; set; } = true;
    public List<GeneralInformationItem> Items { get; set; } = new();
    public int LayoutOrder { get; set; }
    public FontProperties TitleFont { get; set; } = FontProperties.Default;
    public FontProperties ValueFont { get; set; } = FontProperties.Default;
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
}
public record GeneralInformationItem(bool Active, GeneralInformationType Type, string DisplayName);
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