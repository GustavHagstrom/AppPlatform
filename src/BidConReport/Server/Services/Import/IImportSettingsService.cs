using BidConReport.Shared.DTOs;

namespace BidConReport.Server.Services.Import;
public interface IImportSettingsService
{
    Task DeleteSettingsAsync(int settingsId);
    Task<ICollection<EstimationImportSettingsDto>> GetOrganizationSettingsAsync(int organizationId);
    Task<EstimationImportSettingsDto?> GetDefaultSettingsAsync(string userId, int organizationId);
    Task SetAsUserDefault(string userId, int organizationId, int? settingsId);
    Task UpsertImportSettingsAsync(EstimationImportSettingsDto dto);
}