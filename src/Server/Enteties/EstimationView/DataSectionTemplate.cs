using System.ComponentModel.DataAnnotations;

namespace Server.Enteties.EstimationView;

public class DataSectionTemplate : IEstimationViewEntity
{
    [StringLength(450)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public List<DataColumn> Columns { get; set; } = new();
    public int RowCount { get; set; }
    public List<CellTemplate> Cells { get; set; } = new();



    [StringLength(450)]
    public string EstimationViewTemplateId { get; set; } = string.Empty;
    public EstimationViewTemplate? EstimationView { get; set; }
}
