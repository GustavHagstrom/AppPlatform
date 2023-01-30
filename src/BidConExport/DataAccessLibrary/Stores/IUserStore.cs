using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public interface IUserStore
{
    Task CreateAsync(RegisterUserModel registerUserModel);
    Task DeleteAsync(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByIdAsync(string userId);
    Task UpdateAsync(User user);
}