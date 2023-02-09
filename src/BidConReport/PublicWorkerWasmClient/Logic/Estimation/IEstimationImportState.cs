namespace PublicWorkerWasmClient.Logic.Estimation;

public interface IEstimationImportState
{
    bool IsRefreshing { get; }
    DbTreeItem? ItemTree { get; }

    event Action? OnChange;

    Task RefreshItemsAsync();
    IEnumerable<DbTreeItem>? Search(string filterString);
    IEnumerable<DbTreeItem>? SelectedEstimations();
}