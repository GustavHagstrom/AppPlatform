using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AppPlatform.Shared.Builders;
public class MongoCollectionRegistrar(IServiceCollection services)
{
    private readonly Dictionary<Type, string> _collectionNames = [];
    public void Add<T>(string name)
    {
        var type = typeof(T);
        if (_collectionNames.ContainsKey(type))
        {
            throw new InvalidOperationException($"Collection name for type {type.Name} already exists");
        }
        _collectionNames.Add(type, name);
        services.AddSingleton(sp =>
        {
            var db = sp.GetRequiredService<IMongoDatabase>();
            return db.GetCollection<T>(name);
        });
    }
}
