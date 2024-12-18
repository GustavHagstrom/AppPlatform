using AppPlatform.Core.Models.EstimationView;
using AppPlatform.Data.Abstractions;

namespace AppPlatform.Data.EfCore.Stores;
public class SqlViewAccessStore : IViewAccessStore
{
    public Task<List<View>> GetAvailableViewsAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
