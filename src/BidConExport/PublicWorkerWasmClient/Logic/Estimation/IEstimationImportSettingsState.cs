using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Logic.Estimation;
public interface IEstimationImportSettingsState
{
    EstimationImportSettings? CurrentSettings { get; set; }

    event Action? OnSettingsChanged;

    Task<List<EstimationImportSettings>> GetAllSettings();
    Task LoadPreferedSettings();
}