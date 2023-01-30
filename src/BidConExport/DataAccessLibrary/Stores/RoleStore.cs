using DataAccessLibrary.Abstractions;
using SharedLibrary.Models;
using System.Xml.Linq;

namespace DataAccessLibrary.Stores;
public class RoleStore : IRoleStore
{
    private readonly ISqlEngine _sqlEngine;

    public RoleStore(ISqlEngine sqlEngine)
    {
        _sqlEngine = sqlEngine;
    }
    public async Task CreateAsync(UserRole role)
    {
        string sql = "insert into Roles (Id, Name) values (@Id, @Name)";
        await _sqlEngine.SaveDataAsync(sql, role);
    }

    public async Task DeleteAsync(UserRole role)
    {
        string sql = "delete from Roles where Id = @Id";
        await _sqlEngine.SaveDataAsync(sql, role);
    }
    public async Task<UserRole> FindByIdAsync(string roleId)
    {
        string sql = "select * from Roles where Id = @Id";
        var result = await _sqlEngine.LoadDataAsync<UserRole>(sql, new { Id = new Guid(roleId) });
        return result.Single();
    }

    public async Task<UserRole> FindByNameAsync(string name)
    {
        string sql = "select * from Roles where Name = @Name";
        var result = await _sqlEngine.LoadDataAsync<UserRole>(sql, new { Name = name });
        return result.Single();
    }

    public async Task<IEnumerable<UserRole>> GetAllAsync()
    {
        string sql = "select * from Roles";
        return await _sqlEngine.LoadDataAsync<UserRole>(sql);
    }

    public async Task UpdateAsync(UserRole role)
    {
        string sql = "update Roles set Name = @Name where Id = @Id";
        await _sqlEngine.SaveDataAsync(sql, role);
    }
}
