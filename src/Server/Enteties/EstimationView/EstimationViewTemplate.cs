using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class EstimationViewTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public Guid OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public List<DataSectionTemplate> DataSections { get; set; } = new();
    public List<SheetSectionTemplate> SheetSections { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
