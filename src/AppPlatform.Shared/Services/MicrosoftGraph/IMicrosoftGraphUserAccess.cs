using Microsoft.Graph.Models;

namespace AppPlatform.Shared.Services.MicrosoftGraph;
public interface IMicrosoftGraphUserAccess
{
    Task<User?> GetMeAsync();
    Task<UserWithPhoto?> GetMeWithPhotoAsync();
    Task<IEnumerable<User>> GetUsersAsync();
    Task<IEnumerable<UserWithPhoto>> GetUsersWithPhotoAsync();
    
}
