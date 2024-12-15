using AppPlatform.Shared.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace AppPlatform.Shared.Builders;
public class MongoCollectionBuilder(IServiceCollection services)
{
    private readonly Dictionary<Type, string> _collectionNames = [];
    public void Add<T>(string name)
    {
        Add(typeof(T), name);
    }
    public void Add(Type type, string name)
    {
        if(_collectionNames.ContainsKey(type))
        {
            throw new InvalidOperationException($"Collection name for type {type.Name} already exists");
        }
        _collectionNames.Add(type, name);
    }
    public void Build()
    {
        services.AddSingleton(sp =>
        {
            var db = sp.GetRequiredService<IMongoDatabase>();
            return new MongoDbEngine(db, _collectionNames);
        });
    }
}
