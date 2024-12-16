using AppPlatform.Core.Data;
using AppPlatform.Data.MongoDb.Enteties.Authorization;
using MongoDB.Driver;

namespace AppPlatform.Data.MongoDb.Stores;
public class MongoUserAccessStore(IMongoCollection<UserAccess> collection) : MongoStore<UserAccess>(collection)
{
}
