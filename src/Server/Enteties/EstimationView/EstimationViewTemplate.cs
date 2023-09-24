using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class EstimationViewTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }




    public List<DataSectionTemplate> DataSectionTemplates { get; set; } = new();
    public List<SheetSectionTemplate> SheetSectionTemplates { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
