namespace Client.Shared.EstimationViewTemplate.Models;
public class DataColumn
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public List<DataCell> Cells { get; set; } = new();
}
