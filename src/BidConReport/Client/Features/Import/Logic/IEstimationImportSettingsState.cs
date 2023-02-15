using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Logic;
public interface IEstimationImportSettingsState
{
    EstimationImportSettings? CurrentSettings { get; set; }

    event Action? OnSettingsChanged;

    Task<List<EstimationImportSettings>> GetAllSettings();
    Task LoadPreferedSettingsAsync();
}