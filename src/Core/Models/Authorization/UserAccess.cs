using AppPlatform.Core.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Models.Authorization;
public class UserAccess : IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; } = string.Empty;
    public string AccessClaimValue { get; set; } = string.Empty;
}
