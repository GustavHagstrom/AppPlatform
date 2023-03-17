using BidConReport.Shared.Models;

namespace BidConReport.Shared.Features.ReportLayout.Models.Table;
public class TableSection : ILayoutSection
{
    public TableSection()
    {
        Columns = new List<CheckableItem<ColumnDefinition>>
        {
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "Name"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "Quantity"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "DisplayedQuantity"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "RegulatedQuantity"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "Unit"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "DisplayedUnit"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "UnitCost"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "RegulatedUnitCost"}),
            new CheckableItem<ColumnDefinition>(true, new ColumnDefinition{ Type = "Comment"}),
        };
    }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<CheckableItem<ColumnDefinition>> Columns { get; set; }
}
