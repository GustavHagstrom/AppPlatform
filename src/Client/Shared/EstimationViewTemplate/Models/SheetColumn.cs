using SharedLibrary.Enums.ViewTemplate;

namespace Client.Shared.EstimationViewTemplate.Models;
public class SheetColumn
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Order { get; set; }
    public int Width { get; set; }
    public SheetColumnType ColumnType { get; set; }
    //public CellFormat CellFormat { get; set; } = new(); //to be removed
    public SheetCell[] Cells { get; private set; } = new [] 
    { 
        new SheetCell(SheetRowType.Group),
        new SheetCell(SheetRowType.Part),
        new SheetCell(SheetRowType.Post),
    };

}
