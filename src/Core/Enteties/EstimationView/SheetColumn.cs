using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetColumn : IViewEntity, IFormat
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public int Width { get; set; } = 10;
    public bool IsVisible { get; set; } = true;
    public SheetColumnType ColumnType { get; set; }
    //[StringLength(50)]
    //public string CellFormatId { get; set; } = string.Empty;
    //public DataCellFormat? CellFormat { get; set; }

    [StringLength(50)]
    public string SheetSectionTemplateId { get; set; } = string.Empty;
    public SheetSection? SheetSectionTemplate { get; set; }
    [StringLength(50)]
    public string? BackgroundColor { get; set; }
    [StringLength(50)]
    public string? TextColor { get; set; }
    public int FontSize { get; set; } = 12;
    public bool IsBold { get; set; } = false;
    public bool IsItalic { get; set; } = false;
    public bool IsUnderline { get; set; } = false;
    public Align? HorizontalAlign { get; set; } = Align.Start;
    public Align? VerticalAlign { get; set; } = Align.End;
    public TextFormatType FormatType { get; set; } = TextFormatType.Text;
    public bool HasThoasandsSeparator { get; set; } = true;
    public int DecimalCount { get; set; } = 2;
    public bool DoesIncludeTimeOfDay { get; set; } = false;
    public bool HasBorderLeft { get; set; } = false;
    public bool HasBorderTop { get; set; } = false;
    public bool HasBorderRight { get; set; } = false;
    public bool HasBorderBottom { get; set; } = false;
    public BorderStyle BorderStyle { get; set; } = BorderStyle.Solid;

}
