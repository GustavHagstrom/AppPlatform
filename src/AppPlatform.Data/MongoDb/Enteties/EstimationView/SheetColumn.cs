using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Data.MongoDb.Enteties.EstimationView;

public class SheetColumn
{
    public int Order { get; set; }
    public int Width { get; set; } = 10;
    public bool IsVisible { get; set; } = true;
    public SheetColumnType ColumnType { get; set; }
}
