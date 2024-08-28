using AppPlatform.Core.Enums.BidconAccess;
using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetSection : IViewEntity, ISection
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public SheetType SheetType { get; set; }

    public List<SheetColumn> Columns { get; set; } = new()
    { 
        new SheetColumn { Order = 1, Width = 30, ColumnType = SheetColumnType.Description },
        new SheetColumn { Order = 2, Width = 10, ColumnType = SheetColumnType.Quantity },
        new SheetColumn { Order = 3, Width = 10, ColumnType = SheetColumnType.Unit },
        new SheetColumn { Order = 4, Width = 10, ColumnType = SheetColumnType.UnitCost },
        new SheetColumn { Order = 5, Width = 10, ColumnType = SheetColumnType.TotalCost },
        new SheetColumn { Order = 6, Width = 10, ColumnType = SheetColumnType.UnitAskingPrice },
        new SheetColumn { Order = 7, Width = 10, ColumnType = SheetColumnType.TotalAskingPrice },
    };
    public List<SheetRowFormat> RowFormats { get; set; } = new()
    {
        new SheetRowFormat { RowType = SheetRowType.Group },
        new SheetRowFormat { RowType = SheetRowType.Part },
        new SheetRowFormat { RowType = SheetRowType.Post },
        new SheetRowFormat { RowType = SheetRowType.ChangedRow },
        new SheetRowFormat { RowType = SheetRowType.Header },
    };

    [StringLength(450)]
    public string ViewId { get; set; } = string.Empty;
    public View? View { get; set; }
}
