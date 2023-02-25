namespace BidConReport.Shared.Models;
public class EstimationItem
{
    //[BsonIgnore]
    public EstimationItem? Parent { get; set; }
    public int RowNumber { get; set; }
    //public string BidConId { get; set; } = string.Empty;
    //public int BidConRow { get; set; }
    public int? ChangedToRowNumber { get; set; }
    //public int? ParentRowNumber { get; set; }
    public EstimationItemType ItemType { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Unit { get; set; } = string.Empty;
    public string DisplayedUnit { get; set; } = string.Empty;
    public double Quantity { get; set; }
    //public double RegulatedQuantity { get; set; }
    public string DisplayedQuantity { get; set; } = string.Empty;
    public double UnitCost { get; set; }
    //public double RegulatedUnitCost { get; set; }
    //public string? Revision { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string[] StyleTags { get; set; } = Array.Empty<string>();
    public string[] OptionTags { get; set; } = Array.Empty<string>();
    public List<EstimationItem> Items { get; set; } = new();


    public override string ToString()
    {
        return $"{RowNumber} - {Name}";
    }

}
