using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPlatform.Core.Enteties.EstimationView;

public class DataSection : IViewEntity, ISection
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public List<DataColumn> Columns { get; set; } = new();
    public int RowCount { get; set; }
    [NotMapped]
    public int ColumnCount => Columns.Count;
    public List<DataCell> Cells { get; set; } = new();



    [StringLength(50)]
    public string EstimationViewId { get; set; } = string.Empty;
    public View? EstimationView { get; set; }
}
