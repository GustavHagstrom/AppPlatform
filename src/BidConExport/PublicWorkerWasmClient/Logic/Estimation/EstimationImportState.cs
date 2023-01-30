using ApiAccessLibrary.ApiHandlers;
using PublicWorkerWasmClient.Authentication.Services;
using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Logic.Estimation;
public class EstimationImportState : IEstimationImportState
{
    private readonly IBidconApiHandler _bidconApiHandler;
    private readonly ITokenManagerService _tokenManagerService;

    public EstimationImportState(IBidconApiHandler bidconApiHandler, ITokenManagerService tokenManagerService)
    {
        _bidconApiHandler = bidconApiHandler;
        _tokenManagerService = tokenManagerService;
    }
    public DbTreeItem? ItemTree { get; private set; }
    public bool IsRefreshing { get; private set; } = false;
    public async Task RefreshItemsAsync()
    {
        IsRefreshing = true;
        ItemTree = null;
        var token = await _tokenManagerService.GetTokenModelFromLocalStorageAsync();
        if (token != TokenModel.Empty)
        {
            var dbFolder = await _bidconApiHandler.GetFolderAsync(token);
            ItemTree = new DbTreeItem(dbFolder);
            ItemTree.SelectionChanged += NotifyStateChanged;
        }
        IsRefreshing = false;
        NotifyStateChanged();
    }
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    public IEnumerable<DbTreeItem>? SelectedEstimations()
    {
        return ItemTree?.GetAllEstimations().Where(x => x.IsSelected == true);
    }
    public IEnumerable<DbTreeItem>? Search(string filterString)
    {
        var parameters = filterString.Split(" ");
        return ItemTree?.GetAllEstimations().Where(x => AllParametersExists(x, parameters));
    }
    private bool AllParametersExists(DbTreeItem estimationItem, IEnumerable<string> parameters)
    {
        foreach (var parameter in parameters)
        {
            if (!estimationItem.Name.ToLower().Contains(parameter.ToLower()))
            {
                return false;
            }
        }
        return true;
    }
}
