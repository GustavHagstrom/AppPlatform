namespace BidConReport.Shared.DTOs.EstimationView;

public class DataSectionDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Order { get; set; }
    public List<ColumnDefinitionDto> Columns { get; } = new();
    public int RowCount { get; set; }
    public List<CellDto> Cells { get; set; } = new();
}
