using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties.Report;
public class ReportTemplate
{
    public int Id { get; set; }
    [StringLength(50, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(50)]
    public required string OrganizationId { get; set; }
    public int TopLeftHeaderId { get; set; }
    public required HeaderDefinition TopLeftHeader { get; set; }
    public int TopRightHeaderId { get; set; }
    public required HeaderDefinition TopRightHeader { get; set; }
    public int TitleSectionId { get; set; }
    public required TitleSection TitleSection { get; set; }
    public int InformationSectionId { get; set; }
    public required InformationSection InformationSection { get; set; }
    public int PriceSectionId { get; set; }
    public required PriceSection PriceSection { get; set; }
    public int TableSectionId { get; set; }
    public required TableSection TableSection { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
