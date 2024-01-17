using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Server.Enteties;

public class UserOrganization
{
    [StringLength(450)]
    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
    [StringLength(450)]
    public string OrganizationId { get; set; } = string.Empty;
    public Organization? Organization { get; set; }

}

