using AppPlatform.Data.MongoDb.Enteties.Abstractions;

namespace AppPlatform.Data.MongoDb.Enteties.Authorization;
public class UserRole : IUserEntety
{
    public string UserId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;

}
