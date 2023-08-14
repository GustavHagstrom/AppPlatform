namespace BidConReport.Server.Enteties.ReportTemplate;

public class InformationItem
{
    public int Id { get; set; }
    public int InformationSectionId { get; set; }
    public required string Title { get; set; }
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public required string ValueCode { get; set; }
    public int Order { get; set; }
}
