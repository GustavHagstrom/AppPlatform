using BidConReport.DirectAccess.Enums;

namespace BidConReport.DirectAccess.Enteties.EstimationBuild.SheetItems;
public interface ISheetItem
{
    public int Row { get; set; }
    public int ParentRow { get; set; }
    public string Description { get; set; }
    public string? Remark { get; set; }
    public double? Quantity { get; set; }
    public string? Unit { get; set; }
    public double? Cost { get; }
    public bool IsActive { get; set; }
    public RowType RowType { get; }
    public LayerType? LayerType { get; }
    public List<ISheetItem>? SheetItems { get; set; }
}
