using MongoDB.Driver;

namespace AppPlatform.Shared.Data;
public class MongoDbEngine
{
    private readonly IMongoDatabase _database;
    private readonly Dictionary<Type, string> _collectionNames;

    public MongoDbEngine(IMongoDatabase database, Dictionary<Type, string> collectionNames)
    {
        _database = database;
        _collectionNames = collectionNames;
    }
    public IMongoCollection<T> GetCollection<T>()
    {
        var collectionName = _collectionNames[typeof(T)];
        return _database.GetCollection<T>(collectionName);
    }
}
