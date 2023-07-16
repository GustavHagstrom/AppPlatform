namespace BidConReport.Shared.Features.ReportTemplate.Header;
public class HeaderDefinition
{
    public int Id { get; set; }
    public int FontId { get; set; }
    public FontProperties? Font { get; set; } = FontProperties.Default;
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public string ValueCode { get; set; } = string.Empty;
}


