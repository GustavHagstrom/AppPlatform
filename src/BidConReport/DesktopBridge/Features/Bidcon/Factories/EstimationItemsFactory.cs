using BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
using BidConReport.Shared.DTOs;
using BidConReport.Shared.Enums;

namespace BidConReport.DesktopBridge.Features.Bidcon.Factories;

public class EstimationItemsFactory : IEstimationItemsFactory
{
    private readonly IEstimationItemRulesEngine _rulesEngine;

    public EstimationItemsFactory(IEstimationItemRulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine;
    }
    public ICollection<EstimationItemDTO> Create(BidCon.SDK.EstimationItem root, EstimationImportSettingsDTO settings, ref int row, double costFactor)
    {
        return CreateItems(root, settings, ref row, costFactor).ToList();
    }
    private ICollection<EstimationItemDTO> CreateItems(BidCon.SDK.EstimationItem root, EstimationImportSettingsDTO settings, ref int row, double costFactor)
    {
        var items = new List<EstimationItemDTO>();
        if (root.Items is null)
        {
            return items;
        }
        foreach (var item in root.Items)
        {
            if (_rulesEngine.ShouldBeProcessed(item, settings))
            {
                row += 1;
                items.Add(CreateItem(item, settings, ref row, costFactor));
            }
        }
        return items;
    }
    private EstimationItemDTO CreateItem(BidCon.SDK.EstimationItem item, EstimationImportSettingsDTO settings, ref int row, double costFactor)
    {
        var id = Guid.NewGuid();
        var comment = string.Empty;
        var rowNumber = row;
        var changedToRowNumber = row;
        var itemType = (EstimationItemType)Enum.Parse(typeof(EstimationItemType), item.ItemType.ToString());
        var quantity = item.Quantity;
        var displayedQuantity = GetDisplayedQuantity(item);
        var unit = item.Unit;
        var displayedUnit = GetDisplayedUnit(item, settings);
        var unitCost = GetUnitCost(item.UnitCost, settings, costFactor);
        var name = item.Name;
        var tags = GetTags(item, settings).ToArray();
        var items = (itemType == EstimationItemType.Group || itemType == EstimationItemType.Part) ? 
            CreateItems(item, settings, ref row, costFactor).ToList() : 
            new List<EstimationItemDTO>();

        return new EstimationItemDTO
        {
            Id = id,
            Comment = comment,
            RowNumber = rowNumber,
            ChangedToRowNumber = changedToRowNumber,
            ItemType = itemType,
            Quantity = quantity,
            DisplayedQuantity = displayedQuantity,
            Unit = unit,
            DisplayedUnit = displayedUnit,
            UnitCost = unitCost,
            Name = name,
            Tags = tags,
            Items = items
        };
    }
    private IEnumerable<string> GetTags(BidCon.SDK.EstimationItem item, EstimationImportSettingsDTO settings)
    {
        if (item.ItemType == BidCon.SDK.EstimationItemType.Group)
        {
            yield break;
        }
        foreach (var tag in settings!.QuickTags!.Concat(settings.SelectionTags!))
        {
            if (item.Remark.ToLower().Contains(tag.ToLower()))
            {
                yield return tag;
            }
        }
        if (settings.UseRevisionAsSelectionTags && item.Revision is not null && item.Revision.Code is not null)
        {
            yield return item.Revision.Code;
        }
    }
    private double GetUnitCost(double? unitCost, EstimationImportSettingsDTO settings, double costFactor)
    {
        if (unitCost is null)
        {
            return 0;
        }
        return unitCost.Value * costFactor;
    }
    private string GetDisplayedUnit(BidCon.SDK.EstimationItem item, EstimationImportSettingsDTO settings)
    {
        if (item.ItemType == BidCon.SDK.EstimationItemType.Group ||
            item.ItemType == BidCon.SDK.EstimationItemType.Part ||
            (settings.HiddenUnitTag is not null && item.Remark.Contains(settings.HiddenUnitTag)))
        {
            return string.Empty;
        }
        if (item.Reference != string.Empty)
        {
            return item.Reference;
        }
        return item.Unit;
    }
    private string GetDisplayedQuantity(BidCon.SDK.EstimationItem item)
    {
        if (item.ItemType == BidCon.SDK.EstimationItemType.Group ||
            item.ItemType == BidCon.SDK.EstimationItemType.Part ||
            item.ItemType == BidCon.SDK.EstimationItemType.Text)
        {
            return string.Empty;
        }
        if (!string.IsNullOrWhiteSpace(item.Reference))
        {
            return 1.ToString("N1");
        }
        return item.Quantity.ToString("N1");
    }
}
