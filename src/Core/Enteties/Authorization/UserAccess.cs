using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.Authorization;
public class UserAccess : IUserEntety
{
    [StringLength(50)]
    public string UserId { get; set; } = string.Empty;
    public string AccessId { get; set; } = string.Empty;
}
