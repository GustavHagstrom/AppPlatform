using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class UserOrganization
{
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization? Organization { get; set; }

}

