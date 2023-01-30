﻿using SharedLibrary.Models;
using Syncfusion.DocIO.DLS;

namespace PublicWorkerWasmClient.Logic.Estimation;
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
    public event Action? SelectionChanged;
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
    public void SetIsSelectedWithoutNotification(bool value)
    {
        _isSelected = value;
        SetAllSubItemsWithoutNotification(value);
    }
    private void AddEstimations(DbFolder dbFolder)
    {
        foreach (var estimation in dbFolder.DbEstimations)
        {
            var newItem = new DbTreeItem(estimation);
            Items.Add(newItem);
            newItem.SelectionChanged += OnSubItemSelectionChanged;
        }
    }
    private void AddSubFolders(DbFolder dbFolder)
    {
        foreach (var folder in dbFolder.SubFolders)
        {
            var newItem = new DbTreeItem(folder);
            Items.Add(newItem);
            newItem.SelectionChanged += OnSubItemSelectionChanged;
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
    private void NotifySelectionChanged()
    {
        SelectionChanged?.Invoke();
    }
}
