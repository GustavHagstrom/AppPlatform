using SharedLibrary.Enums.ViewTemplate;

namespace AppPlatform.Server.EstimationViewTemplate_old.Models;
public class SheetColumn
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Order { get; set; }
    public int Width { get; set; }
    public SheetColumnType ColumnType { get; set; }
    public SheetCellTemplate[] CellTemplates { get; private set; } = new [] 
    { 
        new SheetCellTemplate(SheetRowType.Group),
        new SheetCellTemplate(SheetRowType.Part),
        new SheetCellTemplate(SheetRowType.Post),
    };

}
