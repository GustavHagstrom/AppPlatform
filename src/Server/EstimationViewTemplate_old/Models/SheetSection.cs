using AppPlatform.Core.Enums.BidconAccess;
using System.Text.Json;

namespace AppPlatform.Server.EstimationViewTemplate_old.Models;

public class SheetSection : IViewSection
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumn> Columns { get; set; } = new();

    public SheetSection Clone()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<SheetSection>(json)!;
    }
}
