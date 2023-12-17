using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class User : IdentityUser
{
    public IEnumerable<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();
    public bool IsDarkMode { get; set; } = false;
    public IEnumerable<UserViewTemplate> UserViewTemplates { get; set; } = new List<UserViewTemplate>();
    public Guid? ActiveOrganizationId { get; set; }
    public Organization? ActiveOrganization { get; set; }
}
