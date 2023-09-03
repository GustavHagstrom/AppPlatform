using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Shared.DTOs.EstimationView;

public class ColumnDefinitionDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType? ColumnType { get; set; }
    public CellFormatDto? CellFormat { get; set; }
}
