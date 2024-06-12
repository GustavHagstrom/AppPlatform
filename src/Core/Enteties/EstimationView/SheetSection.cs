using AppPlatform.Core.Enums.BidconAccess;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetSection : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public SheetType SheetType { get; set; }



    public List<SheetColumn> Columns { get; set; } = new();
    [StringLength(450)]
    public string ViewTemplateId { get; set; } = string.Empty;
    public View? ViewTemplate { get; set; }
}
