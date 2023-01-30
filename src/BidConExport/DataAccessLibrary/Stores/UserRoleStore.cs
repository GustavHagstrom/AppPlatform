using DataAccessLibrary.Abstractions;
using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public class UserRoleStore : IUserRoleStore
{
    private readonly ISqlEngine _sqlEngine;

    public UserRoleStore(ISqlEngine sqlEngine)
    {
        _sqlEngine = sqlEngine;
    }
    public async Task<IEnumerable<UserRole>> GetUserRolesForUser(User user)
    {
        string sql = "select * from UserRoles left join Roles on UserRoles.RoleId = Roles.Id where UserId = @Id";
        return await _sqlEngine.LoadDataAsync<UserRole>(sql, user);
    }
    public async Task AddRoleToUser(User user, UserRole userRole)
    {
        string sql = "insert into UserRoles (UserId, RoleId) value (@UserId, @RoleId)";
        await _sqlEngine.SaveDataAsync(sql, new { UserId = user.Id, RoleId = userRole.Id });
    }
    public async Task RemoveRoleFromUser(User user, UserRole userRole)
    {
        string sql = "delete from UserRoles where UserId = @UserId and RoleId = @RoleId";
        await _sqlEngine.SaveDataAsync(sql, new { UserId = user.Id, RoleId = userRole.Id });
    }
}
