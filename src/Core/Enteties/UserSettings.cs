using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties;
public class UserSettings : IUserEntety
{
    [StringLength(50)]
    [Key]
    public required string UserId { get; set; }
    public bool IsDarkMode { get; set; } = false;
}
