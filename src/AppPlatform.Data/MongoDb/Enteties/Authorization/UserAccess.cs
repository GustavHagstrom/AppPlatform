using AppPlatform.Data.MongoDb.Enteties.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace AppPlatform.Data.MongoDb.Enteties.Authorization;
public class UserAccess : IUserEntety
{
    [BsonId]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = string.Empty;
    public string AccessClaimValue { get; set; } = string.Empty;
}
