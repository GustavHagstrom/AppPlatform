using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate.Table;
public class ColumnDefinition
{
    public int Id { get; set; }
    public int TableSectionId { get; set; }
    public bool IsActive { get; set; }
    public ColumnDataSource DataSource { get; set; }
    public int GroupFontId { get; set; }
    public FontProperties? GroupFont { get; set; } = DefaultGroupFont();
    public int PartFontId { get; set; }
    public FontProperties? PartFont { get; set; } = DefaultPartFont();
    public int CelleFontId { get; set; }
    public FontProperties? CellFont { get; set; } = DefaultCellFont();
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Int represent the % of the width space for the columm to use
    /// </summary>
    [Range(1, 100)]
    public int Width { get; set; }



    private static FontProperties DefaultTitleFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 16;
        return font;
    }
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
public enum ColumnDataSource
{
    RowNumber,
    Name,
    Unit,
    DisplayedUnit,
    Quantity,
    DisplayedQuantity,
    Comment,
}

