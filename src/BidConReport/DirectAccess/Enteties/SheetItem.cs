using BidConReport.BidconDatabaseAccess.Enums;

namespace BidConReport.BidconDatabaseAccess.Enteties;
public class SheetItem
{
    public int Row { get; set; }
    public int ParentRow { get; set; }
    public SheetItem? Parent { get; set; }
    public string? Description { get; set; }
    public string? Remark { get; set; }
    public double? Quantity { get; set; }
    public string? Unit { get; set; }
    public double? UnitCost { get; set; }
    public double? TotalCost { get; set; }
    public bool IsActive { get; set; }
    public int RowType { get; set; }
    public int? LayerType { get; set; }
    public required string LayerId { get; set; }
    public List<SheetItem> SheetItems { get; set; } = new();

    public override string ToString()
    {
        return Description is not null ? Description : nameof(SheetItem);
    }
}
