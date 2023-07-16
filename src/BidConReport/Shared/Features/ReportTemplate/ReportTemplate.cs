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
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string OrganizationId { get; set; } = string.Empty;
    public int TopLeftHeaderId { get; set; }
    public HeaderDefinition TopLeftHeader { get; set; } = new();
    public int TopRightHeaderId { get; set; }
    public HeaderDefinition TopRightHeader { get; set; } = new();
    public int TitleSectionId { get; set; }
    public TitleSection TitleSection { get; set; } = new TitleSection { LayoutOrder = 1 };
    public int InformationSectionId { get; set; }
    public InformationSection InformationSection { get; set; } = InformationSection.Default;
    public int PriceSectionId { get; set; }
    public PriceSection PriceSection { get; set; } = new PriceSection { LayoutOrder = 3 };
    public int TableSectionId { get; set; }
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
