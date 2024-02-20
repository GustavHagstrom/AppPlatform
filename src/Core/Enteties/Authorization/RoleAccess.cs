using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.Authorization;
public class RoleAccess
{
    [StringLength(50)]
    public string RoleId { get; set; } = string.Empty;
    public Role? Role { get; set; }
    public string AccessClaimValue { get; set; } = string.Empty;
}
