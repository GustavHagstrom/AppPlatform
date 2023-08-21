namespace BidConReport.DirectAccess.Enteties;
public class EstimationSheetResult
{
    public Guid EstimationId { get; set; }
    public required string LayerId { get; set; }
    public int Row { get; set; }
    public int ParentRow { get; set; }
    public required string Description { get; set; }
    public required string Remark { get; set; }
    public double? Quantity { get; set; }
    public required string Unit { get; set; }
    public bool IsActive { get; set; }
    public int RowType { get; set; }
    public int SheetType { get; set; }
    public int? LayerType { get; set; }
}
