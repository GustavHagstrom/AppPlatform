using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.Services;

public interface IImportSettingsService
{
    Task<ICollection<EstimationImportSettingsDto>> GetAllAsync();
    Task<EstimationImportSettingsDto?> GetDefaultAsync();
    Task UpsertAsync(EstimationImportSettingsDto settings);
    Task DeleteAsync(int settingsId);
    Task SaveAsDefaultAsync(EstimationImportSettingsDto? settings);
}
