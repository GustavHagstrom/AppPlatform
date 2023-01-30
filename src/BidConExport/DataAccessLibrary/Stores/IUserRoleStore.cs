using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public interface IUserRoleStore
{
    Task AddRoleToUser(User user, UserRole userRole);
    Task<IEnumerable<UserRole>> GetUserRolesForUser(User user);
    Task RemoveRoleFromUser(User user, UserRole userRole);
}