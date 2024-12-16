using AppPlatform.Core.Data;
using AppPlatform.Core.Extensions;
using AppPlatform.Data.Abstractions;
using AppPlatform.Data.MongoDb.Enteties;
using MongoDB.Driver;
using System.Security.Claims;

namespace AppPlatform.Data.MongoDb.Stores;
public class MongoDarkModeStore : MongoStore<UserSettings>, IDarkModeStore
{
    public MongoDarkModeStore(IMongoCollection<UserSettings> collection) : base(collection)
    {
    }

    public async Task<bool> GetAsync(ClaimsPrincipal user)
    {
        var id = user?.GetUserId() ?? throw new ArgumentNullException();
        var settings = await GetByIdAsync(id);
        return settings?.IsDarkMode ?? false;

    }

    public Task SetAsync(ClaimsPrincipal user, bool isDarkMode)
    {
        var id = user?.GetUserId() ?? throw new ArgumentNullException();
        return UpsertAsync(new UserSettings { UserId = id, IsDarkMode = isDarkMode }, id);
    }
}
