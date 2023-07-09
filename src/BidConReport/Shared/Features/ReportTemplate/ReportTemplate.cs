using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Features.ReportTemplate.Information;
using BidConReport.Shared.Features.ReportTemplate.Header;
using BidConReport.Shared.Features.ReportTemplate.Price;
using BidConReport.Shared.Features.ReportTemplate.Table;
using BidConReport.Shared.Features.ReportTemplate.Title;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Features.ReportTemplate;
public class ReportTemplate
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
    public ICollection<IReportTemplateSection> SectionsInOrder => AllSections().OrderBy(x => x.LayoutOrder).ToArray();

    private IEnumerable<IReportTemplateSection> AllSections()
    {
        yield return TitleSection;
        yield return InformationSection;
        yield return PriceSection;
        yield return TableSection;
    }
}
