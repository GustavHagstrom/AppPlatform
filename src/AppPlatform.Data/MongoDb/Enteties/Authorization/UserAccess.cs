using AppPlatform.Data.MongoDb.Enteties.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace AppPlatform.Data.MongoDb.Enteties.Authorization;
public class UserAccess : IUserEntety
{
    [BsonId]
    public string UserId { get; set; } = string.Empty;
    public List<string> AccessClaimValues { get; set; } = [];
}
