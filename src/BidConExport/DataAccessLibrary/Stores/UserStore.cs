using DataAccessLibrary.Abstractions;
using DataAccessLibrary.Helpers;
using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public class UserStore : IUserStore
{
    private readonly ISqlEngine _sqlEngine;

    public UserStore(ISqlEngine sqlEngine)
    {
        _sqlEngine = sqlEngine;
    }
    public async Task CreateAsync(RegisterUserModel registerUserModel)
    {
        var user = new User 
        { 
            Email = registerUserModel.Email, 
            FirstName = registerUserModel.FirstName, 
            LastName = registerUserModel.LastName,
        };
        PasswordHasher.AddHashAndSaltToUser(user, registerUserModel.Password);
        string sql = "insert into Users (Id, Email, FirstName, LastName, PasswordHash, Salt, RefreshToken) values (@Id, @Email, @FirstName, @LastName, @PasswordHash, @Salt, @RefreshToken)";
        await _sqlEngine.SaveDataAsync(sql, user);
    }

    public async Task DeleteAsync(User user)
    {
        string sql = "delete from Users where Id = @Id";
        await _sqlEngine.SaveDataAsync(sql, user);
    }

    public async Task<User> FindByIdAsync(string userId)
    {
        string sql = "select * from Users where Id = @Id";
        var result = await _sqlEngine.LoadDataAsync<User>(sql, new { Id = userId });
        return result.Single();
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        string sql = "select * from Users where Email = @Email";
        var result = await _sqlEngine.LoadDataAsync<User>(sql, new { Email = email });
        return result.Single();
    }
    public async Task UpdateAsync(User user)
    {
        string sql = "update Users set Email = @Email, FirstName = @FirstName, LastName = @LastName, PasswordHash = @PasswordHash, Salt = @Salt, RefreshToken = @RefreshToken where Id = @Id";
        await _sqlEngine.SaveDataAsync(sql, user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        string sql = "select * from Users";
        return await _sqlEngine.LoadDataAsync<User>(sql);
    }
}
