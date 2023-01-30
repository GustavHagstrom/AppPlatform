using DataAccessLibrary.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataAccessLibrary.Engines;
public class MongoEngine : IMongoEngine
{
    private readonly IConfiguration _configuration;

    public MongoEngine(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IMongoCollection<T> GetMongoCollection<T>(string dbName, string collectionName)
    {
        var client = new MongoClient(_configuration. GetValue<string>(Constants.MongoConnectopmStringKey));
        var db = client.GetDatabase(dbName);
        return db.GetCollection<T>(collectionName);
    }
    public async Task DeleteAsync<T>(FilterDefinition<T> filter, string dbName, string collectionName)
    {
        var collection = GetMongoCollection<T>(dbName, collectionName);
        await collection.DeleteOneAsync(filter);
    }

    public async Task<T> FindAsync<T>(FilterDefinition<T> filter, string dbName, string collectionName)
    {
        var collection = GetMongoCollection<T>(dbName, collectionName);
        var results = await collection.FindAsync(filter);
        return results.FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string dbName, string collectionName)
    {
        var collection = GetMongoCollection<T>(dbName, collectionName);
        var results = await collection.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task UpsertAsync<T>(FilterDefinition<T> filter, T entity, string dbName, string collectionName)
    {
        var collection = GetMongoCollection<T>(dbName, collectionName);
        await collection.ReplaceOneAsync(filter, entity, new ReplaceOptions { IsUpsert = true });
    }

    public async Task InsertAsync<T>(T entity, string dbName, string collectionName)
    {
        var collection = GetMongoCollection<T>(dbName, collectionName);
        await collection.InsertOneAsync(entity);
    }
}
