using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Models;
public class EstimationItem
{
    //[BsonIgnore]
    public required Guid Id { get; set; }
    [NotMapped]
    public EstimationItem? Parent { get; set; }
    public required int RowNumber { get; set; }
    //public string BidConId { get; set; } = string.Empty;
    //public int BidConRow { get; set; }
    public int? ChangedToRowNumber { get; set; }
    //public int? ParentRowNumber { get; set; }
    public required EstimationItemType ItemType { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(10)]
    public required string Unit { get; set; }
    [MaxLength(10)]
    public required string DisplayedUnit { get; set; }
    public required double Quantity { get; set; }
    //public double RegulatedQuantity { get; set; }
    public required string DisplayedQuantity { get; set; }
    public required double UnitCost { get; set; }
    //public double RegulatedUnitCost { get; set; }
    //public string? Revision { get; set; }
    [MaxLength(2000)]
    public required string Comment { get; set; }
    public required QuickTag[] QuickTags { get; set; }
    public required SelectionTag[] SelectionTags { get; set; }
    public required List<EstimationItem> Items { get; set; } = new();


    public override string ToString()
    {
        return $"{RowNumber} - {Name}";
    }

}
