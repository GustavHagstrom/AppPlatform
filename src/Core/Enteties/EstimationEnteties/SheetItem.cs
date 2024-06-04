using System.ComponentModel.DataAnnotations;

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

    //Costs other than base Layeritem costs should be calculated in the frontend
    //public double? UnitCost { get; set; }
    //public double? TotalCost => UnitCost * Quantity;
    //public double? UnitAskingPrice { get; set; }
    //public double? TotalAskingPrice => UnitAskingPrice * Quantity;
    public IEnumerable<SheetItem> AllInOrder
    {
        get
        {
            return new[] { this }.Concat(Children.SelectMany(x => x.AllInOrder).OrderBy(x => x.Position));
        }
    }
}