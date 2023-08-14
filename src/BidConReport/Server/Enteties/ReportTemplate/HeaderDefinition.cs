namespace BidConReport.Server.Enteties.ReportTemplate;
public class HeaderDefinition
{
    public int Id { get; set; }
    public int FontId { get; set; }
    public required FontProperties Font { get; set; }
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public required string ValueCode { get; set; }
}


