using BidCon.MM.Properties;
using BidCon.SDK;
using BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
using BidConReport.Shared.Models;
using Syncfusion.DocIO.DLS;
using System.Runtime.CompilerServices;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;
public class EstimationFactory : IEstimationFactory
{
    private readonly IEstimationItemRulesEngine _rulesEngine;

    private EstimationImportSettings? Settings { get; set; }
    private double? CostFactor { get; set; }
    public EstimationFactory(IEstimationItemRulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine;
    }
    public Shared.Models.Estimation Create(BidCon.SDK.Estimation estimation, EstimationImportSettings settings)
    {
        Settings = settings;

        //var resources = GetResources(estimation.SummarySheet);// (Resource[])estimation.SummarySheet.Items;
        
        CostFactor = GetSummarySheetResourceAccountValue(settings.CostFactorAccount, estimation);
        var costBeforeChanges = GetSummarySheetResourceAccountValue(settings.CostBeforeChangesAccount, estimation);
        var endPageNetCost = GetSummarySheetResourceAccountValue(settings.NetCostAccount, estimation);

        return new Shared.Models.Estimation
        {
            Id = Guid.NewGuid(),
            BidConId = estimation.ID.ToString(),
            OrganizationId = Settings.OrganizationId,
            Name = estimation.Name,
            Description = estimation.Description,
            CreationDate = DateTime.Now,
            //ExpirationDate = settings.ExpirationDate,
            CostBeforeChanges = costBeforeChanges + (estimation.NetSheet.TotalCost - endPageNetCost) * CostFactor!.Value,
            Currency = estimation.Currency,
            QuickTags = settings.QuickTags.ToArray(),
            SelectionTags = settings.SelectionTags.ToArray(),
            Items = CreateEstimationItemsRecursivly(estimation.NetSheet.Items),
            LockedCategories = CreateLockedCategories(estimation).ToList(),
        };
    }
    private static double GetSummarySheetResourceAccountValue(string account, BidCon.SDK.Estimation estimation)
    {
        var allSummarySheetResources = GetResources(estimation.SummarySheet);
        var accountSpecifiResources = allSummarySheetResources!.Where(x => x.Account.Code == account).ToList();
        if (accountSpecifiResources.Count == 0) throw new Exception($"""Required resource with account "{account}" does not exist""");
        if (accountSpecifiResources.Count > 1) throw new Exception($"""Required resource with account "{account}" has more than one occurance""");
        return accountSpecifiResources.First().TotalCost;
    }
    private IEnumerable<LockedCategory> CreateLockedCategories(BidCon.SDK.Estimation estimation)
    {
        if (estimation.LockedStages is not null)
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
    }

    private IEnumerable<LockedStage> CreateLockedStages(BidCon.SDK.EstimationItem category)
    {
        foreach (var stage in category.Items)
        {
            yield return new LockedStage
            {
                Name = stage.Name,
                Items = CreateEstimationItemsRecursivly(stage.Items)
            };
        }
    }

    private List<Shared.Models.EstimationItem> CreateEstimationItemsRecursivly(BidCon.SDK.EstimationItem[] items, Shared.Models.EstimationItem? parent = null, int row = 0)//, int? parentRow = null)
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
            subItems.AddRange(CreateEstimationItemsRecursivly(item.Items, parent, row));
        }
        return subItems;
    }
    private Shared.Models.EstimationItem CreateSimpleEstimationItem(BidCon.SDK.EstimationItem item, int row, Shared.Models.EstimationItem? parent = null)
    {
        return new Shared.Models.EstimationItem
        {
            Id = Guid.NewGuid(),
            Comment = string.Empty,
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
            Tags = GetTags(item).ToArray(),
            Items = new HashSet<Shared.Models.EstimationItem>()
            //Revision = item.Revision?.Code,
            //QuickTags = GetTagsFromRemark(item, Settings!.QuickTags).ToArray(),
            //SelectionTags = GetSelectionTags(item),// GetTags(item, Settings!.OptionTags).ToArray(),
        };
    }

    //private string[] GetSelectionTags(BidCon.SDK.EstimationItem item)
    //{
    //    var tags = GetTags(item, Settings!.SelectionTags).ToList();
    //    if (item.Revision is not null && item.Revision.Code is not null)
    //    {
    //        tags.Add(item.Revision.Code);
    //    }
    //    return tags.ToArray();
    //}
    private IEnumerable<string> GetTags(BidCon.SDK.EstimationItem estimationItem)//, IEnumerable<string> TagsTemplate)
    {
        foreach (var tag in Settings!.QuickTags.Concat(Settings.SelectionTags))
        {
            if (estimationItem.Remark.ToLower().Contains(tag.ToLower()))
            {
                yield return tag;
            }
        }
        if (Settings.UseRevisionAsSelectionTags && estimationItem.Revision is not null && estimationItem.Revision.Code is not null)
        {
            yield return estimationItem.Revision.Code;
        }
    }
    //private static IEnumerable<SelectionTag> GetTags(BidCon.SDK.EstimationItem estimationItem, IEnumerable<SelectionTag> TagsTemplate)
    //{
    //    foreach (var tag in TagsTemplate)
    //    {
    //        if (estimationItem.Remark.ToLower().Contains(tag.Value.ToLower()))
    //        {
    //            yield return tag;
    //        }
    //    }
    //}
    private string GetDisplayedUnit(BidCon.SDK.EstimationItem estimationItem)
    {
        if (estimationItem.ItemType == BidCon.SDK.EstimationItemType.Group || estimationItem.ItemType == BidCon.SDK.EstimationItemType.Part || estimationItem.Remark.Contains(Settings!.HiddenUnitTag))
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
