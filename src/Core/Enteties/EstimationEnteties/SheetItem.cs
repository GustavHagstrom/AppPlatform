using AppPlatform.Core.Enums.BidconAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppPlatform.Core.Enteties.EstimationEnteties;

public class SheetItem
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public string EstimationId { get; set; } = string.Empty;
    public Estimation? Estimation { get; set; }
    public string Description { get; set; } = string.Empty;
    [StringLength(50)]
    public string? ParentId { get; set; }
    public SheetItem? Parent { get; set; }
    public int Position { get; set; }
    public int RowType { get; set; }
    public double? Quantity { get; set; }
    public List<SheetItem> Children { get; set; } = new List<SheetItem>();
    public string Remark { get; set; } = string.Empty;
    public string? Unit { get; set; }

    /// <summary>
    /// Is null for all RowTypes but LayerdItems
    /// </summary>
    public double? LayerItemUnitCost { get; set; }
    /// <summary>
    /// Is null for all RowTypes but LayerdItems
    /// </summary>
    public double? LayerItemUnitAskingPrice { get; set; }


    [NotMapped]
    public double? UnitCost => RowType == (int)Enums.BidconAccess.RowType.LayeredItem ? LayerItemUnitCost : Children.Sum(x => x.TotalCost);
    [NotMapped]
    public double? TotalCost => UnitCost * (Quantity is null ? 1 : Quantity);
    [NotMapped]
    public double? UnitAskingPrice => RowType == (int)Enums.BidconAccess.RowType.LayeredItem ? LayerItemUnitAskingPrice : Children.Sum(x => x.TotalAskingPrice);
    [NotMapped]
    public double? TotalAskingPrice => UnitAskingPrice * (Quantity is null ? 1 : Quantity);

    public IEnumerable<SheetItem> AllInOrder
    {
        get
        {
            return new[] { this }.Concat(Children.SelectMany(x => x.AllInOrder).OrderBy(x => x.Position));
        }
    }
}