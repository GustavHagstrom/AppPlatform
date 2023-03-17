using BidConReport.Shared.Models;

namespace BidConReport.Shared.Features.ReportLayout.Models.GeneralInformation;
public class GeneralInformationSection : ILayoutSection
{
    public GeneralInformationSection()
    {
        Items = new List<GeneralInformationItem>
        {
            new(true, "Name", x => x.Name, 1),
            new(true, "Description", x => x.Description ?? string.Empty, 1),
            new(true, "Creation Date", x => x.CreationDate.ToString("yyyy-MM-dd"), 1),
            new(true, "Expiration Date", x => x.ExpirationDate?.ToString("yyyy-MM-dd") ?? string.Empty, 1),
            new(true, "Print Date", x => x.PrintDate.ToString("yyyy-MM-dd HH:mm:ss"), 1),
            new(true, "Supervisor", x => x.Supervisor ?? string.Empty, 1),
            new(true, "Representative", x => x.Representative ?? string.Empty, 1),
            new(true, "Currency", x => x.Currency, 1),

        };
    }
    public bool IsEnabled { get; set; } = true;
    public List<GeneralInformationItem> Items { get; set; }
    public int LayoutOrder { get; set; }
    public FontProperties TitleFont { get; set; } = FontProperties.Default;
    public FontProperties ValueFont { get; set; } = FontProperties.Default;
}
//Maybe not a solution as Func needs to be saved to the DB
public record GeneralInformationItem(bool Active, string Title, Func<Estimation, string> ValueFunc, int Order);
