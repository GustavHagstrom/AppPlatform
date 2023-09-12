using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Shared.DTOs.EstimationView;

public class CellFormatTemplateDto
{
    public required string FontFamily { get; set; }
    public int FontSize { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public Align Align { get; set; }
    public Justify Justify { get; set; }
    public TextFormatType FormatType { get; set; }
    public bool ThoasandsSeparator { get; set; }
    public int DecimalCount { get; set; }
    public bool IncludeTimeOfDay { get; set; }
    public required BorderTemplateDto Border { get; set; }
}
