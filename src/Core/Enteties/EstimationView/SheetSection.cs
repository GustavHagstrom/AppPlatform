using AppPlatform.Core.Enums.BidconAccess;
using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetSection : IViewEntity, ISection
{
    public SheetSection()
    {
        Id = Guid.NewGuid().ToString();
        CellFormats = CreateCellFormats(Id).ToList();
    }
    [StringLength(50)]
    public string Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; } = "SheetSection";
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
    public List<SheetCellFormat> CellFormats { get; set; }

    [StringLength(450)]
    public string ViewId { get; set; } = string.Empty;
    public View? View { get; set; }


    private IEnumerable<SheetCellFormat> CreateCellFormats(string sectionId)
    {
        foreach (var columnType in Enum.GetValues<SheetColumnType>())
        {
            foreach (var rowType in Enum.GetValues<SheetRowType>())
            {
                yield return new SheetCellFormat
                {
                    SheetSectionId = sectionId,
                    ColumnType = columnType,
                    RowType = rowType
                };
            }
        }
    }
}
