namespace DataAccessLibrary.Abstractions;
public interface ISqlEngine
{
    Task SaveDataAsync(string sql, object? parameter = null);
    Task<IEnumerable<T>> LoadDataAsync<T>(string sql, object? parameter = null);
}
