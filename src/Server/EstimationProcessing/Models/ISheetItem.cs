namespace AppPlatform.Server.EstimationProcessing.Models;

public interface ISheetItem
{
    string Description { get; set; }
    ISheetItem? Parent { get; }
    int Position { get; }
    double? Quantity { get; set; }
    List<ISheetItem> Children { get; }
    string? Unit { get; }
    double? UnitCost { get; }
    double? TotalCost { get; }
    double? UnitAskingPrice { get; }
    double? TotalAskingPrice { get; }
    public IEnumerable<ISheetItem> AllInOrder
    {
        get
        {
            return new[] { this }.Concat(Children.SelectMany(x => x.AllInOrder).OrderBy(x => x.Position));
        }
    }
}