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
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task LoadPreferedSettingsAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        CurrentSettings = new EstimationImportSettings
        {
            SettingsName = "SampleSettings",
            CostBeforeChangesAccount = "9001",
            CostFactorAccount = "9002",
            NetCostAccount = "9003",
            HiddenTag = "{dold}",
            StyleTags = new List<string> { "SM", "F", "K", "NE", "H" },
            OptionTags = new List<string> { "1", "2", "3","4","5","6","7" }
        };
    }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<List<EstimationImportSettings>> GetAllSettings()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        if (CurrentSettings is null)
        {
            return new List<EstimationImportSettings>();
        }
        return new List<EstimationImportSettings>{ CurrentSettings };
    }
    public event Action? OnSettingsChanged;
    private void NotifySettingsChanged() => OnSettingsChanged?.Invoke();
}
