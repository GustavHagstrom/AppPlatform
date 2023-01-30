using Dapper;
using DataAccessLibrary.Abstractions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
//using System.Data.SqlClient;

namespace DataAccessLibrary.Engines;
public class DapperEngine : ISqlEngine
{
    private readonly IConfiguration _configuration;
    public DapperEngine(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<IEnumerable<T>> LoadDataAsync<T>(string sql, object? param = null)
    {
        using (var cnn = new MySqlConnection(_configuration.GetValue<string>(Constants.SqlConnectionStringKey)))
        {
            return await cnn.QueryAsync<T>(sql, param);
        }
    }

    public async Task SaveDataAsync(string sql, object? param = null)
    {
        using (var cnn = new MySqlConnection(_configuration.GetValue<string>(Constants.SqlConnectionStringKey)))
        {
            await cnn.ExecuteAsync(sql, param);
        }
    }
}
