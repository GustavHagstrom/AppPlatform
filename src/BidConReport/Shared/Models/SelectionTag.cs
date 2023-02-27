using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Models;
public class SelectionTag
{
    public required int Id { get; set; }
    [MaxLength(30)]
    public required string Value { get; set; }
}
