namespace SharedLibrary.DTOs.EstimationView;




public class DataSectionTemplateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Order { get; set; }
    public List<DataColumnDto> Columns { get; set; } = new();
    public int RowCount { get; set; }
    public List<CellTemplateDto> Cells { get; set; } = new();

    public Guid EstimationViewTemplateId { get; set; }
}
