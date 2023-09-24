namespace Server.Enteties.EstimationView;

public class DataSectionTemplate : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public List<DataColumn> Columns { get; set; } = new();
    public int RowCount { get; set; }
    public List<CellTemplate> Cells { get; set; } = new();



    public Guid EstimationViewTemplateId { get; set; }
    public EstimationViewTemplate? EstimationView { get; set; }
}
