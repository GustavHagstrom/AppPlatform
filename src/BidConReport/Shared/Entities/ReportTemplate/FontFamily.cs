using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Entities.ReportTemplate;
public class FontFamily
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Value { get; set; }
}
