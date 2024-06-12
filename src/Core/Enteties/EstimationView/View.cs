using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class View : IViewEntity, ITenantEntety
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public required string Name { get; set; }
    public List<DataSection> DataSections { get; set; } = new();
    public List<SheetSection> SheetSections { get; set; } = new();
    public Footer? Footer { get; set; }
    public Header? Header { get; set; }
    [StringLength(50)]
    public string TenantId { get; set; } = string.Empty;
}
