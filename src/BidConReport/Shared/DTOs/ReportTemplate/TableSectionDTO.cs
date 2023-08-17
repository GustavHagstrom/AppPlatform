using BidConReport.Shared.Enums;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class TableSectionDto : IReportTemplateSectionDTO
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public List<ColumnDefinitionDTO> Columns { get; set; } = new()
    {
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.Name, Width = 30, Order = 0 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.RowNumber, Width = 10, Order = 1 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.Quantity, Width = 10, Order = 2 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.DisplayedQuantity, Width = 10, Order = 3 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.Comment, Width = 20, Order = 4 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.DisplayedUnit, Width = 10, Order = 5 },
        new ColumnDefinitionDTO{ DataSource = ColumnDataSource.Unit, Width = 10, Order = 6 },
    };
    public int GroupFontId { get; set; }
    public FontPropertiesDto GroupFont { get; set; } = DefaultGroupFont();
    public int PartFontId { get; set; }
    public FontPropertiesDto PartFont { get; set; } = DefaultPartFont();
    public int CellFontId { get; set; }
    public FontPropertiesDto CellFont { get; set; } = DefaultCellFont();
    public int ColumnHeaderFontId { get; set; }
    public FontPropertiesDto ColumnHeaderFont { get; set; } = DefaultColumnHeaderFont();

    public static TableSectionDto Default => new()
    {
        LayoutOrder = 4,
    };
    private static FontPropertiesDto DefaultGroupFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = true;
        font.FontSize = 20;
        return font;
    }
    private static FontPropertiesDto DefaultPartFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
    private static FontPropertiesDto DefaultCellFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = false;
        font.FontSize = 11;
        return font;
    }
    private static FontPropertiesDto DefaultColumnHeaderFont()
    {
        var font = FontPropertiesDto.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
}
