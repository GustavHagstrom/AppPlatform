using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportTemplate;
public class FontFamily
{
    public int Id { get; set; }
    [MaxLength(50)]
    public required string Value { get; set; } 
}
