using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Shared.DTOs.EstimationView;

public class SheetColumnTemplateDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType? ColumnType { get; set; }
    public CellFormatTemplateDto? CellFormat { get; set; }
}
