using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class View : IViewEntity, ITenantEntety
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public List<DataSection> DataSections { get; set; } = new();
    public List<SheetSection> SheetSections { get; set; } = new();
    public Footer? Footer { get; set; } = new Footer { Value = string.Empty };
    public Header? Header { get; set; } = new Header { Value = string.Empty };
    [StringLength(50)]
    public string TenantId { get; set; } = string.Empty;
}
