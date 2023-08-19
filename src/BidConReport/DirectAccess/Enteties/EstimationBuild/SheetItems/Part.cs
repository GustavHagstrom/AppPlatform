using BidConReport.DirectAccess.Enums;

namespace BidConReport.DirectAccess.Enteties.EstimationBuild.SheetItems;
public class Part
{
    public int Row { get; set; }
    public int ParentRow { get; set; }
    public required string Description { get; set; }
    public string? Remark { get; set; }
    public double? Quantity { get; set; }
    public string? Unit { get; set; }

    public double? Cost => SheetItems is not null ? SheetItems.Sum(item => item.Cost ?? 0) * (Quantity ?? 1) : 0;
    public bool IsActive { get; set; }
    public RowType RowType => RowType.Part;
    public LayerType? LayerType => null;
    public List<ISheetItem>? SheetItems { get; set; }
}
