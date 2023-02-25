﻿using BidCon.SDK;
using BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
using BidConReport.Shared.Models;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public class SimpleEstimationFactory : ISimpleEstimationFactory
{
    private readonly IEstimationItemRulesEngine _rulesEngine;

    private EstimationImportSettings? Settings { get; set; }
    private double? CostFactor { get; set; }
    public SimpleEstimationFactory(IEstimationItemRulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine;
    }
    public Shared.Models.Estimation CreateSimpleEstimation(BidCon.SDK.Estimation estimation, EstimationImportSettings settings)
    {
        var resources = GetResources(estimation.SummarySheet);// (Resource[])estimation.SummarySheet.Items;
        CostFactor = resources!.Where(x => x.Account.Code == settings.CostFactorAccount).Single().TotalCost;
        Settings = settings;
        var costBeforeChanges = resources!.Where(x => x.Account.Code == settings.CostBeforeChangesAccount).Single().TotalCost;
        var endPageNetCost = resources!.Where(x => x.Account.Code == settings.NetCostAccount).Single().TotalCost;
        return new Shared.Models.Estimation
        {
            BidConId = estimation.ID.ToString(),
            Name = estimation.Name,
            Description = estimation.Description,
            CreationDate = DateTime.Now,
            //ExpirationDate = settings.ExpirationDate,
            CostBeforeChanges = costBeforeChanges + (estimation.NetSheet.TotalCost - endPageNetCost) * CostFactor!.Value,
            Currency = estimation.Currency,
            StyleTags = settings.StyleTags.ToArray(),
            OptionTags = settings.OptionTags.ToArray(),
            Items = CreateSimpleEstimationItemsRecursivly(estimation.NetSheet.Items),
            LockedCategories = CreateLockedCategories(estimation).ToList(),
        };
    }

    private IEnumerable<LockedCategory> CreateLockedCategories(BidCon.SDK.Estimation estimation)
    {
        foreach (var category in estimation.LockedStages.Items)
        {
            yield return new LockedCategory
            {
                Name = category.Name,
                LockedStages = CreateLockedStages(category).ToList(),
            };
        }
    }

    private IEnumerable<LockedStage> CreateLockedStages(BidCon.SDK.EstimationItem category)
    {
        foreach (var stage in category.Items)
        {
            yield return new LockedStage
            {
                Name = stage.Name,
                Items = CreateSimpleEstimationItemsRecursivly(stage.Items)
            };
        }
    }

    private List<Shared.Models.EstimationItem> CreateSimpleEstimationItemsRecursivly(BidCon.SDK.EstimationItem[] items, Shared.Models.EstimationItem? parent = null, int row = 0)//, int? parentRow = null)
    {
        var returnlist = new List<Shared.Models.EstimationItem>();
        foreach (var item in items)
        {
            if (_rulesEngine.ShouldBeProcessed(item, Settings!))
            {
                row += 1;
                var simpleItem = CreateSimpleEstimationItem(item, row, parent);
                simpleItem.Items = GetSubItems(item, row, simpleItem);
                returnlist.Add(simpleItem);
            }
        }
        return returnlist;
    }

    private List<Shared.Models.EstimationItem> GetSubItems(BidCon.SDK.EstimationItem item, int row, Shared.Models.EstimationItem? parent = null)
    {
        var subItems = new List<Shared.Models.EstimationItem>();
        if (item.ItemType == BidCon.SDK.EstimationItemType.Part || item.ItemType == BidCon.SDK.EstimationItemType.Group)
        {
            subItems.AddRange(CreateSimpleEstimationItemsRecursivly(item.Items, parent, row));
        }
        return subItems;
    }
    private Shared.Models.EstimationItem CreateSimpleEstimationItem(BidCon.SDK.EstimationItem item, int row, Shared.Models.EstimationItem? parent = null)
    {
        return new Shared.Models.EstimationItem
        {
            RowNumber = row,
            //BidConId = item.ID,
            //BidConRow = item.RowNum,
            //ParentRowNumber = parent?.RowNumber,
            //Parent = parent,
            ChangedToRowNumber = row,
            //Items = GetSubItems(item),
            ItemType = (Shared.Models.EstimationItemType)Enum.Parse(typeof(Shared.Models.EstimationItemType), item.ItemType.ToString()),
            Quantity = item.Quantity,
            //RegulatedQuantity = item.Quantity - item.OriginalQuantity,
            DisplayedQuantity = GetDisplayedQuantity(item),
            Unit = item.Unit,
            DisplayedUnit = GetDisplayedUnit(item),
            UnitCost = GetUnitCost(item.UnitCost),
            //RegulatedUnitCost = GetUnitCost(item.RegulatedCost),
            Name = item.Name,
            //Revision = item.Revision?.Code,
            StyleTags = GetTags(item, Settings!.StyleTags).ToArray(),
            OptionTags = GetOptionTags(item),// GetTags(item, Settings!.OptionTags).ToArray(),
        };
    }

    private string[] GetOptionTags(BidCon.SDK.EstimationItem item)
    {
        var tags = GetTags(item, Settings!.OptionTags).ToList();
        if (item.Revision is not null && item.Revision.Code is not null)
        {
            tags.Add(item.Revision.Code);
        }
        return tags.ToArray();
    }

    private static string GetDisplayedUnit(BidCon.SDK.EstimationItem estimationItem)
    {
        if (estimationItem.ItemType == BidCon.SDK.EstimationItemType.Group || estimationItem.ItemType == BidCon.SDK.EstimationItemType.Part)
        {
            return string.Empty;
        }
        if (estimationItem.Reference != string.Empty)
        {
            return estimationItem.Reference;
        }
        return estimationItem.Unit;
    }
    private static string GetDisplayedQuantity(BidCon.SDK.EstimationItem estimationItem)
    {
        if (!string.IsNullOrWhiteSpace(estimationItem.Reference))
        {
            return 1.ToString("N1");
        }
        if (estimationItem.ItemType == BidCon.SDK.EstimationItemType.Group || estimationItem.ItemType == BidCon.SDK.EstimationItemType.Part || estimationItem.ItemType == BidCon.SDK.EstimationItemType.Text)
        {
            return string.Empty;
        }
        return estimationItem.Quantity.ToString("N1");
    }
    private static IEnumerable<string> GetTags(BidCon.SDK.EstimationItem estimationItem, IEnumerable<string> TagsTemplate)
    {
        foreach (string tag in TagsTemplate)
        {
            if (estimationItem.Remark.ToLower().Contains(tag.ToLower()))
            {
                yield return tag;
            }
        }
    }
    private double GetUnitCost(double? unitCost)
    {
        if (unitCost == null)
        {
            return 0;
        }
        return unitCost.Value * CostFactor!.Value;
    }
    private static List<Resource> GetResources(BidCon.SDK.EstimationItem estimationItem)
    {
        var resources = new List<Resource>();
        if (estimationItem is Resource resource)
        {
            resources.Add(resource);
            return resources;
        }
        foreach (var item in estimationItem.Items)
        {
            resources.AddRange(GetResources(item));
        }
        return resources;
    }
}
