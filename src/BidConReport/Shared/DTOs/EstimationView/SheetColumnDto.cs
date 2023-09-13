using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Shared.DTOs.EstimationView;

public class SheetColumnDto
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }

    public required CellFormatDto CellFormat { get; set; }
    public Guid NetSheetSectionTemplateId { get; set; }
}
