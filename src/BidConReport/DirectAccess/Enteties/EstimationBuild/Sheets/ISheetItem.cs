using Syncfusion.DocIO.DLS;

namespace BidConReport.BidconAccess.Enteties.EstimationBuild.Sheets;

public interface ISheetItem
{
    string Description { get; set; }
    //bool IsActive { get; set; }
    //string LayerId { get; }
    //int? LayerType { get; }
    ISheetItem? Parent { get; }
    //int ParentRow { get; }
    double? Quantity { get; set; }
    //string? Remark { get; set; }
    //int Row { get; }
    //int RowType { get; }
    List<ISheetItem> Children { get; }
    string? Unit { get; }
    double? UnitCost { get; }
    double? TotalCost { get; }
    public IEnumerable<ISheetItem> AllInOrder  
    {
        get
        {
            yield return this;
            foreach (var child in Children)
            {
                foreach (var subChild in child.AllInOrder)
                {
                    yield return subChild;
                }
            }
        }
    }
}