using BidConReport.Shared.DTOs.ReportTemplate;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Client.Shared.Services.EstimationReport.Models;
public class CellFormat
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string FontFamily { get; set; } = "Calibri";
    [Range(1, 200)]
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
}
