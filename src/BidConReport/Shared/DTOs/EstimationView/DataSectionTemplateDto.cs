namespace BidConReport.Shared.DTOs.EstimationView;

public class DataSectionTemplateDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public List<ColumnDto> Columns { get; } = new();
    public int RowCount { get; set; }
    public List<CellTemplateDto> Cells { get; set; } = new();
}
