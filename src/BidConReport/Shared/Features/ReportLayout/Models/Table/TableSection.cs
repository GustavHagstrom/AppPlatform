using BidConReport.Shared.Models;

namespace BidConReport.Shared.Features.ReportLayout.Models.Table;
public class TableSection : ILayoutSection
{
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<ColumnDefinition> Columns { get; set; } = new();
    public static TableSection Default => new()
    {
        Columns = new()
        {
            new ColumnDefinition{ DataSource = ColumnDataSource.Name, Width = 4 },
            new ColumnDefinition{ DataSource = ColumnDataSource.RowNumber, Width = 1 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Quantity, Width = 1 },
            new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedQuantity, Width = 1 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Comment, Width = 3 },
            new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedUnit, Width = 1 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Unit, Width = 1 },
        }
            
    };
}
