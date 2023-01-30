using SharedLibrary.Models;

namespace DataAccessLibrary.Stores;
public class EstimationImportSettingsStore : IEstimationImportSettingsStore
{
    public async Task CreateAsync(EstimationImportSettings settings)
    {
        throw new NotImplementedException();
    }
    public async Task<EstimationImportSettings> GetByNameAsync(string settingsName)
    {
        throw new NotImplementedException();
    }
    public async Task<EstimationImportSettings> GetPreferedAsync(User user)
    {
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<EstimationImportSettings>> GetAll()
    {
        throw new NotImplementedException();
    }
    public async Task UpdateAsync(EstimationImportSettings settings)
    {
        throw new NotImplementedException();
    }
    public async Task Delete(string settingsName)
    {
        throw new NotImplementedException();
    }
}
