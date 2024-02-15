using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.Authorization;
public class UserNativeRoles : IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; } = string.Empty;
    [StringLength(50)]
    public string NativeUserRole { get; set; } = string.Empty;
}
