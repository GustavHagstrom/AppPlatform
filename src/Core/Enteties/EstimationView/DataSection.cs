using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class DataSection : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public List<DataColumn> Columns { get; set; } = new();
    public int RowCount { get; set; }
    public List<DataCell> Cells { get; set; } = new();



    [StringLength(50)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public View? EstimationView { get; set; }
}
