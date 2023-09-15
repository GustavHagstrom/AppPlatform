using BidConReport.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class Role
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    [StringLength(50)]
    public required string Name { get; set; }
    public IEnumerable<User>? Users { get; set; }
    public IEnumerable<Right>? Rights { get; set; }
}
