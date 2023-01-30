using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public interface IRoleStore
{
    Task CreateAsync(UserRole role);
    Task DeleteAsync(UserRole role);
    Task<IEnumerable<UserRole>> GetAllAsync();
    Task<UserRole> FindByIdAsync(string roleId);
    Task<UserRole> FindByNameAsync(string name);
    Task UpdateAsync(UserRole role);
}