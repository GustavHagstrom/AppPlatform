using BidConReport.Shared.Models;

namespace BidConReport.Client.Features.Import.Models;
public class DbTreeItem
{
    private bool _isSelected;

    public DbTreeItem(DbFolder dbFolder, bool isSelected = false)
    {
        Type = DbTreeItemType.Folder;
        _isSelected = isSelected;
        Name = dbFolder.Name;
        AddEstimations(dbFolder);
        AddSubFolders(dbFolder);
    }
    public DbTreeItem(DbEstimation dbEstimation, bool isSelected = false)
    {
        Type = DbTreeItemType.Estimation;
        _isSelected = isSelected;
        Id = dbEstimation.Id;
        Name = dbEstimation.ToString();
    }
    public DbTreeItemType Type { get; private set; }
    public bool IsSelected
    {
        get => _isSelected; set
        {
            _isSelected = value;
            SetAllSubItemsWithoutNotification(value);
            NotifySelectionChanged();
        }
    }
    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public HashSet<DbTreeItem> Items { get; private set; } = new();
    //public event Action? SelectionChanged;
    public Action? SelectionChanged { get; set; }
    public IEnumerable<DbTreeItem> GetAllEstimations()
    {
        foreach (var item in Items)
        {
            if (item.Type == DbTreeItemType.Estimation)
            {
                yield return item;
            }
            foreach (var subEstimation in item.GetAllEstimations())
            {
                yield return subEstimation;
            }
        }
    }
    public IEnumerable<DbTreeItem> SelectedEstimations()
    {
        return GetAllEstimations().Where(x => x.IsSelected == true);
    }
    public IEnumerable<DbTreeItem> Search(string filterString)
    {
        var parameters = filterString.Split(" ");
        return GetAllEstimations().Where(x => AllParametersExists(x, parameters));
    }
    private static bool AllParametersExists(DbTreeItem estimationItem, IEnumerable<string> parameters)
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
    private void AddEstimations(DbFolder dbFolder)
    {
        foreach (var estimation in dbFolder.DbEstimations)
        {
            var newItem = new DbTreeItem(estimation);
            Items.Add(newItem);
            newItem.SelectionChanged = OnSubItemSelectionChanged;
        }
    }
    private void AddSubFolders(DbFolder dbFolder)
    {
        foreach (var folder in dbFolder.SubFolders)
        {
            var newItem = new DbTreeItem(folder);
            Items.Add(newItem);
            newItem.SelectionChanged = OnSubItemSelectionChanged;
        }
    }
    private void OnSubItemSelectionChanged()
    {
        _isSelected = Items.Any(x => x.IsSelected);
        NotifySelectionChanged();
    }
    private void SetAllSubItemsWithoutNotification(bool value)
    {
        foreach (var item in Items)
        {
            item.SetIsSelectedWithoutNotification(value);
        }
    }
    private void SetIsSelectedWithoutNotification(bool value)
    {
        _isSelected = value;
        SetAllSubItemsWithoutNotification(value);
    }
    private void NotifySelectionChanged()
    {
        SelectionChanged?.Invoke();
    }
}
