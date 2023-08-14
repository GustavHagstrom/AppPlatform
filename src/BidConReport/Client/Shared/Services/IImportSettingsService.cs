using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettingsDTO>> GetAllAsync();
    Task<EstimationImportSettingsDTO?> GetDefaultAsync();
    Task UpsertAsync(EstimationImportSettingsDTO settings);
    Task DeleteAsync(int settingsId);
    Task SaveAsDefaultAsync(EstimationImportSettingsDTO? settings);
}
