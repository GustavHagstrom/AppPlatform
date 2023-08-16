using BidConReport.Shared.Enums;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class TableSectionDTO : IReportTemplateSectionDTO
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
    public FontPropertiesDTO GroupFont { get; set; } = DefaultGroupFont();
    public int PartFontId { get; set; }
    public FontPropertiesDTO PartFont { get; set; } = DefaultPartFont();
    public int CellFontId { get; set; }
    public FontPropertiesDTO CellFont { get; set; } = DefaultCellFont();
    public int ColumnHeaderFontId { get; set; }
    public FontPropertiesDTO ColumnHeaderFont { get; set; } = DefaultColumnHeaderFont();

    public static TableSectionDTO Default => new()
    {
        LayoutOrder = 4,
    };
    private static FontPropertiesDTO DefaultGroupFont()
    {
        var font = FontPropertiesDTO.Default;
        font.Bold = true;
        font.FontSize = 20;
        return font;
    }
    private static FontPropertiesDTO DefaultPartFont()
    {
        var font = FontPropertiesDTO.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
    private static FontPropertiesDTO DefaultCellFont()
    {
        var font = FontPropertiesDTO.Default;
        font.Bold = false;
        font.FontSize = 11;
        return font;
    }
    private static FontPropertiesDTO DefaultColumnHeaderFont()
    {
        var font = FontPropertiesDTO.Default;
        font.Bold = true;
        font.FontSize = 14;
        return font;
    }
}
