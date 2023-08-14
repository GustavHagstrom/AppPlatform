using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties;

public class User
{
    [StringLength(50)]
    public required string Id { get; set; }
    public bool IsDarkMode { get; set; } = false;
    public ICollection<UserOrganization>? UserOrganizations { get; set; }
}
