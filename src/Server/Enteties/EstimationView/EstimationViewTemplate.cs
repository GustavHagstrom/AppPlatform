using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;
public class EstimationViewTemplate : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public List<DataSectionTemplate> DataSections { get; set; } = new();
    public List<SheetSectionTemplate> SheetSections { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
}
