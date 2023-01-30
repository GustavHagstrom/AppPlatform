namespace DataAccessLibrary.Abstractions;
public interface IGenericCrud<T>
{
    Task CreatAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync<I>(I id);
    Task UpsertAsync<I>(I id, T entity);
    Task DeleteAsync<I>(I id);
}
