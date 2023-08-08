using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Entities.ReportTemplate.Table;
public class TableSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<ColumnDefinition> Columns { get; set; } = new()
    {
        new ColumnDefinition{ DataSource = ColumnDataSource.Name, Width = 30, Order = 0 },
        new ColumnDefinition{ DataSource = ColumnDataSource.RowNumber, Width = 10, Order = 1 },
        new ColumnDefinition{ DataSource = ColumnDataSource.Quantity, Width = 10, Order = 2 },
        new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedQuantity, Width = 10, Order = 3 },
        new ColumnDefinition{ DataSource = ColumnDataSource.Comment, Width = 20, Order = 4 },
        new ColumnDefinition{ DataSource = ColumnDataSource.DisplayedUnit, Width = 10, Order = 5 },
        new ColumnDefinition{ DataSource = ColumnDataSource.Unit, Width = 10, Order = 6 },
    };
    public int GroupFontId { get; set; }
    public FontProperties GroupFont { get; set; } = DefaultGroupFont();
    public int PartFontId { get; set; }
    public FontProperties PartFont { get; set; } = DefaultPartFont();
    public int CellFontId { get; set; }
    public FontProperties CellFont { get; set; } = DefaultCellFont();
    public int ColumnHeaderFontId { get; set; }
    public FontProperties ColumnHeaderFont { get; set; } = DefaultColumnHeaderFont();

    [NotMapped]
    public static TableSection Default => new()
    {
        LayoutOrder = 4,
    };
    private static FontProperties DefaultGroupFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 20;
        return font;
    }
    private static FontProperties DefaultPartFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
    private static FontProperties DefaultCellFont()
    {
        var font = FontProperties.Default;
        font.Bold = false;
        font.FontSize = 11;
        return font;
    }
    private static FontProperties DefaultColumnHeaderFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
}
