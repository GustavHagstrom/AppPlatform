
using MongoDB.Driver;

namespace AppPlatform.Shared.Data;
internal class MongoRepository<T> : IRepository<T> where T : class
{
    //constructor inject mongo client
    public MongoRepository(IMongoClient client)
    {
        //create database
        var database = client.GetDatabase("appplatform");
        //create collection
        var collection = database.GetCollection<T>(typeof(T).Name);
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpsertAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
