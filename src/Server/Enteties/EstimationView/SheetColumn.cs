using SharedLibrary.Enums.ViewTemplate;

namespace Server.Enteties.EstimationView;

public class SheetColumn : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }

    public required CellFormat CellFormat { get; set; }
    public Guid NetSheetSectionTemplateId { get; set; }
    public SheetSectionTemplate? NetSheetSectionTemplate { get; set; }
}
