using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class ReportTemplateDTO
{
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public string OrganizationId { get; set; } = string.Empty;
    public int TopLeftHeaderId { get; set; }
    public HeaderDefinitionDTO TopLeftHeader { get; set; } = new();
    public int TopRightHeaderId { get; set; }
    public HeaderDefinitionDTO TopRightHeader { get; set; } = new();
    public int TitleSectionId { get; set; }
    public TitleSectionDTO TitleSection { get; set; } = new TitleSectionDTO { LayoutOrder = 1 };
    public int InformationSectionId { get; set; }
    public InformationSectionDTO InformationSection { get; set; } = InformationSectionDTO.Default;
    public int PriceSectionId { get; set; }
    public PriceSectionDTO PriceSection { get; set; } = new PriceSectionDTO { LayoutOrder = 3 };
    public int TableSectionId { get; set; }
    public TableSectionDTO TableSection { get; set; } = TableSectionDTO.Default;

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
