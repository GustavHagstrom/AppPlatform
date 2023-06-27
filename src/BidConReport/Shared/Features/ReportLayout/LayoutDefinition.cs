using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Features.ReportLayout.Information;
using BidConReport.Shared.Features.ReportLayout.Header;
using BidConReport.Shared.Features.ReportLayout.Price;
using BidConReport.Shared.Features.ReportLayout.Table;
using BidConReport.Shared.Features.ReportLayout.Title;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Features.ReportLayout;
public class LayoutDefinition
{
    public int Id { get; set; }
    public required string Name { get; set; }
    [MaxLength(50)]
    public string OrganizationId { get; set; } = string.Empty;
    public HeaderDefinition TopLeftHeader { get; set; } = new();
    public HeaderDefinition TopRightHeader { get; set; } = new();
    public TitleSection TitleSection { get; set; } = new TitleSection { LayoutOrder = 1 };
    public InformationSection InformationSection { get; set; } = InformationSection.Default;
    public PriceSection PriceSection { get; set; } = new PriceSection { LayoutOrder = 3 };
    public TableSection TableSection { get; set; } = TableSection.Default;

    [NotMapped]
    public ICollection<ILayoutSection> SectionsInOrder => AllSections().OrderBy(x => x.LayoutOrder).ToArray();

    private IEnumerable<ILayoutSection> AllSections()
    {
        yield return TitleSection;
        yield return InformationSection;
        yield return PriceSection;
        yield return TableSection;
    }
}
