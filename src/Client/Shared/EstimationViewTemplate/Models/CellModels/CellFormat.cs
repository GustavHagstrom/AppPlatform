using SharedLibrary.Enums.ViewTemplate;

namespace Client.Shared.EstimationViewTemplate.Models.CellModels;

public class CellFormat
{
    public Guid Id { get; set; }
    public string FontFamily { get; set; } = "Calibri";
    public int FontSize { get; set; } = 11;
    public bool Bold { get; set; } = false;
    public bool Italic { get; set; } = false;
    public bool Underline { get; set; } = false;
    public Align Align { get; set; } = Align.Left;
    public Justify Justify { get; set; } = Justify.Bottom;
    public TextFormatType FormatType { get; set; } = TextFormatType.Text;
    public bool ThoasandsSeparator { get; set; } = true;
    public int DecimalCount { get; set; } = 0;
    public bool IncludeTimeOfDay { get; set; } = false;
    public bool BorderLeft { get; set; }
    public bool BorderTop { get; set; }
    public bool BorderRight { get; set; }
    public bool BorderBottom { get; set; }
    public int BorderThickness => 1;
    public BorderStyle BorderStyle { get; set; }
}
