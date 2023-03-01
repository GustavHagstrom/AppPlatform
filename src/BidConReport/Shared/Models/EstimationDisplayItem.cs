namespace BidConReport.Shared.Models;
public class EstimationDisplayItem
{
   
    public required double UnitApriceCost { get; set; }
    
  


    public required int RowNumber { get; set; }
    public required string BidConId { get; set; }
    
    public int? ParentRowNumber { get; set; }
    public required EstimationItemType ItemType { get; set; }
    public required string Name { get; set; }
    public required string Unit { get; set; }
    public required string DisplayedUnit { get; set; }
    public required double Quantity { get; set; }
    public required string DisplayedQuantity { get; set; }
    public required double UnitCost { get; set; }
    public required int? ChangedFromRowNumber { get; set; }
    public required double PriceDifference { get; set; }
    public required bool CanBeChanged { get; set; }
    public required bool IsOriginalItem { get; set; }
    public required int Level { get; set; }
    public required string Comment { get; set; }
}
