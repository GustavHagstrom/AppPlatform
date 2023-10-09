using SharedLibrary.Enums.ViewTemplate;

namespace Client.Shared.EstimationViewTemplate.Models;

public class SheetCell
{
    public SheetCell(SheetRowType rowType)
    {
        RowType = rowType;
    }
    public Guid Id { get; set; }
    public CellFormat CellFormat { get; set; } = new();
    public int TopPadding { get; set; }
    public SheetRowType RowType { get; private set; }

    
}
