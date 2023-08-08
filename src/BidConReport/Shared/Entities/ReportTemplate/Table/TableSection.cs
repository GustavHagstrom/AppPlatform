using BidConReport.Shared.Entities;
using BidConReport.Shared.Entities.ReportTemplate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Entities.ReportTemplate.Table;
public class TableSection : IReportTemplateSection
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<ColumnDefinition> Columns { get; set; } = new();
    public int GroupFontId { get; set; }
    public FontProperties GroupFont { get; set; } = DefaultGroupFont();
    public int PartFontId { get; set; }
    public FontProperties PartFont { get; set; } = DefaultPartFont();
    public int CellFontId { get; set; }
    public FontProperties CellFont { get; set; } = DefaultCellFont();

    [NotMapped]
    public static TableSection Default => new()
    {
        LayoutOrder = 4,
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
}
