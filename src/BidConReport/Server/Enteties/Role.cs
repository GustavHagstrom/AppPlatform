using BidConReport.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class Role
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public ICollection<User>? Users { get; set; }
    public ICollection<ApplicationRight>? Rights { get; set; }
}
