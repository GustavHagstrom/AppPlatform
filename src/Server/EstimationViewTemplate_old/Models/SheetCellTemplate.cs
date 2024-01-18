using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Server.EstimationViewTemplate_old.Models;

public class SheetCellTemplate
{
    public SheetCellTemplate(SheetRowType rowType)
    {
        RowType = rowType;
    }
    public Guid Id { get; set; }
    public CellFormat CellFormat { get; set; } = new();
    public SheetRowType RowType { get; private set; }

    
}
