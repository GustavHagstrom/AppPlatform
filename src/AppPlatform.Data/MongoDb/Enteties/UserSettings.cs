using AppPlatform.Data.MongoDb.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Data.MongoDb.Enteties;
public class UserSettings : IUserEntety
{
    [StringLength(50)]
    [Key]
    public required string UserId { get; set; }
    public bool IsDarkMode { get; set; } = false;
}
