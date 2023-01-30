using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public interface IEstimationImportSettingsStore
{
    Task CreateAsync(EstimationImportSettings settings);
    Task Delete(string settingsName);
    Task<IEnumerable<EstimationImportSettings>> GetAll();
    Task<EstimationImportSettings> GetByNameAsync(string settingsName);
    Task<EstimationImportSettings> GetPreferedAsync(User user);
    Task UpdateAsync(EstimationImportSettings settings);
}