using BidConReport.Shared.Entities;

namespace BidConReport.Shared.Features.ReportLayout.Table;
public class TableSection : ILayoutSection
{
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<ColumnDefinition> Columns { get; set; } = new();
    public static TableSection Default => new()
    {
        Columns = new()
        {
            new ColumnDefinition{ DataSource = ColumnDataSource.Name, Width = 30 },
            new ColumnDefinition{ DataSource = ColumnDataSource.RowNumber, Width = 10 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Quantity, Width = 10 },
            new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedQuantity, Width = 10 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Comment, Width = 20 },
            new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedUnit, Width = 10 },
            new ColumnDefinition{ DataSource = ColumnDataSource.Unit, Width = 10 },
        }

    };
}
