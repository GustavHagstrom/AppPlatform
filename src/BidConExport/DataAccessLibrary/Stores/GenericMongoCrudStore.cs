using DataAccessLibrary.Abstractions;
using MongoDB.Driver;

namespace DataAccessLibrary.Stores;
public class GenericMongoCrudStore<T> : IGenericCrud<T>
{
    public GenericMongoCrudStore(IMongoEngine mongoEngine)
    {
        this.mongoEngine = mongoEngine;
        collectionName = typeof(T).Name;
    }
    public const string GENERIC_MONGO_DB_NAME = "GenericDb";
    public readonly string collectionName;
    private readonly IMongoEngine mongoEngine;
    

    public async Task CreatAsync(T entity)
    {
        await mongoEngine.InsertAsync(entity, GENERIC_MONGO_DB_NAME, collectionName);
    }

    public async Task DeleteAsync<I>(I id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        await mongoEngine.DeleteAsync(filter, GENERIC_MONGO_DB_NAME, collectionName);
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await mongoEngine.GetAllAsync<T>(GENERIC_MONGO_DB_NAME, collectionName);
    }

    public async Task<T> GetAsync<I>(I id)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        return await mongoEngine.FindAsync<T>(filter, GENERIC_MONGO_DB_NAME, collectionName);
    }

    public async Task UpsertAsync<I>(I id, T entity)
    {
        if (IdNotPresentInEntity(id, entity))
        {
            throw new Exception($"Id: {id} was not found in entity {entity}");
        }
        var filter = Builders<T>.Filter.Eq("Id", id);
        await mongoEngine.UpsertAsync(filter, entity, GENERIC_MONGO_DB_NAME, collectionName);
    }

    private bool IdNotPresentInEntity<I>(I id, T entity)
    {
        var type = entity!.GetType();
        var value = (I)type.GetProperty("Id")!.GetValue(entity)!;
        return !value.Equals(id);
    }
}
