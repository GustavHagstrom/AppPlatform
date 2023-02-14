using BidConReport.Client.Features.Import.Models;

namespace BidConReport.Client.Features.Import.Logic;

public interface IEstimationImportState
{
    bool IsRefreshing { get; }
    DbTreeItem? ItemTree { get; }

    event Action? OnChange;

    Task RefreshItemsAsync();
    IEnumerable<DbTreeItem>? Search(string filterString);
    IEnumerable<DbTreeItem>? SelectedEstimations();
}