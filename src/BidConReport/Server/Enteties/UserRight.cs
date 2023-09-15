using BidConReport.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class UserRight
{
    public Guid Id { get; set; }
    public ApplicationRight Right { get; set; }
    [StringLength(50)]
    public required string UserId { get; set; }
    public User? User { get; set; }
}
