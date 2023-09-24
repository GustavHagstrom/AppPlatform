using Client.Shared.EstimationViewTemplate.Models.CellModels;
using System.Text.Json;

namespace Client.Shared.EstimationViewTemplate.Models.SectionModels;

public class DataSection : IViewSection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public List<DataColumn> Columns { get; } = new();
    public int RowCount { get; set; }
    public List<Cell> Cells { get; set; } = new();

    public DataSection Clone()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<DataSection>(json)!;
    }
}
