using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Logic;
public class EstimationImportSettingsState : IEstimationImportSettingsState
{

    private EstimationImportSettings? _currentSettings;

    public EstimationImportSettingsState()
    {

    }
    public EstimationImportSettings? CurrentSettings
    {
        get => _currentSettings; set
        {
            _currentSettings = value;
            NotifySettingsChanged();
        }
    }
    public async Task LoadPreferedSettings()
    {
        throw new NotImplementedException();
    }
    public async Task<List<EstimationImportSettings>> GetAllSettings()
    {
        throw new NotImplementedException();
    }
    public event Action? OnSettingsChanged;
    private void NotifySettingsChanged() => OnSettingsChanged?.Invoke();
}
