using AppPlatform.Data.MongoDb.Enteties.Abstractions;
using MongoDB.Bson.Serialization.Attributes;

namespace AppPlatform.Data.MongoDb.Enteties;
public class UserSettings : IUserEntety
{
    [BsonId]
    public required string UserId { get; set; }
    public bool IsDarkMode { get; set; } = false;
}
