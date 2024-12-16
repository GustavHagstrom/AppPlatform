
using AppPlatform.Data.Abstractions;
using MongoDB.Driver;

namespace AppPlatform.Core.Data;
internal class MongoStore<T> : IDataStore<T> where T : class
{
    private readonly IMongoCollection<T> collection;

    public MongoStore(IMongoCollection<T> collection)
    {
        this.collection = collection;
    }

    public Task DeleteAsync(string id)
    {
        return collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await collection.Find(Builders<T>.Filter.Empty).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        var result = await collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        return result;
    }

    public Task UpsertAsync(T entity, string id)
    {
        return collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity, new ReplaceOptions { IsUpsert = true });
    }
}
