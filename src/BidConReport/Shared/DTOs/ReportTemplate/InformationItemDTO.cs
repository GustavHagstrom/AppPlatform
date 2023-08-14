using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.DTOs.ReportTemplate;

public class InformationItemDTO
{
    public int Id { get; set; }
    public int InformationSectionId { get; set; }
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public string ValueCode { get; set; } = string.Empty;
    public int Order { get; set; }
}
