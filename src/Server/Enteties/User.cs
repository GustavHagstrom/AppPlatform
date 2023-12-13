using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Server.Enteties;

public class User : IdentityUser
{
    public IEnumerable<UserOrganization>? UserOrganizations { get; set; }
    public bool IsDarkMode { get; set; } = false;
    public IEnumerable<UserViewTemplate>? UserViewTemplates { get; set; }
}
