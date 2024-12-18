using AppPlatform.Core.Models.EstimationView;

namespace AppPlatform.Data.Abstractions;
public interface IViewAccessStore
{
    Task<List<View>> GetAvailableViewsAsync(string userId);
}
