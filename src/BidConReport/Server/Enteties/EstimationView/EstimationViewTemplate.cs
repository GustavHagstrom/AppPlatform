using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties.EstimationView;
public class EstimationViewTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }




    public List<DataSectionTemplate> DataSectionTemplates { get; set; } = new();
    public NetSheetSectionTemplate? NetSheetSectionTemplate { get; set; }
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
