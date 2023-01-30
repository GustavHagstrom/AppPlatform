using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccessLibrary.Abstractions;
public interface IMongoEngine
{
    Task InsertAsync<T>(T entity, string dbName, string collectionName);
    Task UpsertAsync<T>(FilterDefinition<T> filter, T entity, string dbName, string collectionName);
    Task<IEnumerable<T>> GetAllAsync<T>(string dbName, string collectionName);
    Task<T> FindAsync<T>(FilterDefinition<T> filter, string dbName, string collectionName);
    Task DeleteAsync<T>(FilterDefinition<T> filter, string dbName, string collectionName);
}
