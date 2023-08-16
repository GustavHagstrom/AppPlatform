using BidConReport.Shared.DTOs;

namespace BidConReport.Server.Services.Import;
public interface IImportSettingsService
{
    Task DeleteSettingsAsync(int settingsId);
    Task<ICollection<EstimationImportSettingsDto>> GetOrganizationSettingsAsync(string organizationId);
    Task<EstimationImportSettingsDto?> GetDefaultSettingsAsync(string userId, string organizationId);
    Task SetAsUserDefault(string userId, string organizationId, int? settingsId);
    Task UpsertImportSettingsAsync(EstimationImportSettingsDto dto);
}