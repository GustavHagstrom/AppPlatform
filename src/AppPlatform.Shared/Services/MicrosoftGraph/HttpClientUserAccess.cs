using Microsoft.Graph.Models;

namespace AppPlatform.Shared.Services.MicrosoftGraph;
internal class HttpClientUserAccess : IMicrosoftGraphUserAccess
{
    public Task<User?> GetMeAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserWithPhoto?> GetMeWithPhotoAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserWithPhoto>> GetUsersWithPhotoAsync()
    {
        throw new NotImplementedException();
    }
}
