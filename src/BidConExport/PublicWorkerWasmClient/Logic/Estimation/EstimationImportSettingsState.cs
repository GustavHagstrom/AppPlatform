using PublicWorkerWasmClient.Authentication.Services;
using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Logic.Estimation;
public class EstimationImportSettingsState : IEstimationImportSettingsState
{
	private readonly ITokenManagerService _tokenManagerService;
	private EstimationImportSettings? _currentSettings;

	public EstimationImportSettingsState(ITokenManagerService tokenManagerService)
	{
		_tokenManagerService = tokenManagerService;
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
