using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class SheetCellFormat : IFormat
{
    [StringLength(50)]

    public string SheetSectionId { get; set; } = Guid.NewGuid().ToString();
    public SheetSection? SheetSection { get; set; }
    public SheetRowType RowType { get; set; }
    public SheetColumnType ColumnType { get; set; }


    public Align? HorizontalAlign { get; set; }
    public string? BackgroundColor { get; set; }
    public BorderStyle BorderStyle { get; set; }
    public int DecimalCount { get; set; }
    public bool DoesIncludeTimeOfDay { get; set; }
    public int FontSize {   get; set; }
    public TextFormatType FormatType { get; set; }
    public bool HasBorderBottom { get; set; }
    public bool HasBorderLeft { get; set; }
    public bool HasBorderRight { get; set; }
    public bool HasBorderTop { get; set; }
    public bool HasThoasandsSeparator { get; set; }
    public bool IsBold { get; set; }
    public bool IsItalic { get; set; }
    public bool IsUnderline { get; set; }
    public Align? VerticalAlign { get; set; }
    public string? TextColor { get; set; }
}
