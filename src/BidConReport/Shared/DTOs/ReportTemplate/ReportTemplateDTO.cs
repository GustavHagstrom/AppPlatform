using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class ReportTemplateDto
{
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    public int OrganizationId { get; set; }
    public int TopLeftHeaderId { get; set; }
    public HeaderDefinitionDto TopLeftHeader { get; set; } = new();
    public int TopRightHeaderId { get; set; }
    public HeaderDefinitionDto TopRightHeader { get; set; } = new();
    public int TitleSectionId { get; set; }
    public TitleSectionDto TitleSection { get; set; } = new TitleSectionDto { LayoutOrder = 1 };
    public int InformationSectionId { get; set; }
    public InformationSectionDto InformationSection { get; set; } = InformationSectionDto.Default;
    public int PriceSectionId { get; set; }
    public PriceSectionDto PriceSection { get; set; } = new PriceSectionDto { LayoutOrder = 3 };
    public int TableSectionId { get; set; }
    public TableSectionDto TableSection { get; set; } = TableSectionDto.Default;

    public ICollection<IReportTemplateSectionDTO> SectionsInOrder => AllSections().OrderBy(x => x.LayoutOrder).ToArray();

    private IEnumerable<IReportTemplateSectionDTO> AllSections()
    {
        yield return TitleSection;
        yield return InformationSection;
        yield return PriceSection;
        yield return TableSection;
    }
    public override string ToString()
    {
        return Name;
    }
}
