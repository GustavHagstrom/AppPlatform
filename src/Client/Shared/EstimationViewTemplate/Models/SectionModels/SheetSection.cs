using SharedLibrary.Enums.BidconAccess;
using System.Text.Json;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class SheetSection : IViewSection
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumn> Columns { get; set; } = new();
    public List<SheetRow> Rows { get; set; } = new();
    
    //Managing this will required some lifting 
    //Adding and removing rows/columns should be reflected here in both UI and DB
    public List<SheetCell> Cells { get; set; } = new(); 

    public SheetSection Clone()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<SheetSection>(json)!;
    }
}
