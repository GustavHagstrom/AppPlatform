using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class User
{
    [StringLength(50)]
    public required string Id { get; set; }
    [StringLength(50)]
    public required string OrganizationId { get; set; }
    public Organization? Organization { get; set; }
    public bool IsDarkMode { get; set; } = false;
    public License? License { get; set; }
    public Guid? RoleId { get; set; }
    public Role? Role { get; set; }
    public IEnumerable<Right>? Rights { get; set; }
}
