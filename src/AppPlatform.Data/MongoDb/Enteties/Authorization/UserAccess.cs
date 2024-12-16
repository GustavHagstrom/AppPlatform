using AppPlatform.Data.MongoDb.Enteties.Abstractions;

namespace AppPlatform.Data.MongoDb.Enteties.Authorization;
public class UserAccess : IUserEntety
{
    public string UserId { get; set; } = string.Empty;
    public string AccessClaimValue { get; set; } = string.Empty;
}
