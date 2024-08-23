using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Core.Enteties.EstimationView;
public interface IFormat
{
    Align? Align { get; set; }
    string? BackgroundColor { get; set; }
    BorderStyle BorderStyle { get; set; }
    int DecimalCount { get; set; }
    bool DoesIncludeTimeOfDay { get; set; }
    int FontSize { get; set; }
    TextFormatType FormatType { get; set; }
    bool HasBorderBottom { get; set; }
    bool HasBorderLeft { get; set; }
    bool HasBorderRight { get; set; }
    bool HasBorderTop { get; set; }
    bool HasThoasandsSeparator { get; set; }
    bool IsBold { get; set; }
    bool IsItalic { get; set; }
    bool IsUnderline { get; set; }
    Justify? Justify { get; set; }
    string? TextColor { get; set; }
}