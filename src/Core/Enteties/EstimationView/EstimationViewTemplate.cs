using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class EstimationViewTemplate : IEstimationViewEntity, ITenantEntety
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public required string Name { get; set; }
    public List<DataSectionTemplate> DataSections { get; set; } = new();
    public List<SheetSectionTemplate> SheetSections { get; set; } = new();
    public List<HeaderOrFooter> HeaderOrFooters { get; set; } = new();
    public string TenantId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
