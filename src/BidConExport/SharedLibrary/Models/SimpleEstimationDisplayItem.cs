namespace SharedLibrary.Models;
public class SimpleEstimationDisplayItem
{
   
    public double UnitApriceCost { get; set; }
    
  


    public int RowNumber { get; set; }
    public string BidConId { get; set; } = string.Empty;
    
    public int? ParentRowNumber { get; set; }
    public SimpleEstimationItemType ItemType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string DisplayedUnit { get; set; } = string.Empty;
    public double Quantity { get; set; }
    public string DisplayedQuantity { get; set; } = string.Empty;
    //public double RegulatedQuantity { get; set; }
    public double UnitCost { get; set; }
    //public double RegulatedUnitCost { get; set; }
    
    //public string? Revision { get; set; }
    

    public int? ChangedFromRowNumber { get; set; }
    public double PriceDifference { get; set; }
    public bool CanBeChanged { get; set; }
    public bool IsOriginalItem { get; set; }
    public int Level { get; set; }
    public string Comment { get; set; } = string.Empty;
    //public List<SimpleEstimationItem> Items { get; set; } = new();
    //public string[] StyleTags { get; set; } = Array.Empty<string>();
    //public string[] OptionTags { get; set; } = Array.Empty<string>();
}
