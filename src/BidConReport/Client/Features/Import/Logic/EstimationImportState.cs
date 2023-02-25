using BidConReport.Client.Features.Import.Models;

namespace BidConReport.Client.Features.Import.Logic;
public class EstimationImportState : IEstimationImportState
{
    private readonly IBidConImporter _bidConImporter;

    public EstimationImportState(IBidConImporter bidConImporter)
    {
        _bidConImporter = bidConImporter;
    }
    public DbTreeItem? ItemTree { get; private set; }
    public bool IsRefreshing { get; private set; } = false;
    public async Task RefreshItemsAsync()
    {
        IsRefreshing = true;
        ItemTree = null;

        var dbFolderResult = await _bidConImporter.GetFoldersAsync();
        if (dbFolderResult.Value is not null)
        {
            ItemTree = new DbTreeItem(dbFolderResult.Value);
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
