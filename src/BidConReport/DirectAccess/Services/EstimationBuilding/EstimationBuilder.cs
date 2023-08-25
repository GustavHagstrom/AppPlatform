﻿using BidConReport.BidconAccess.Enteties;
using BidConReport.BidconAccess.Enteties.EstimationBuild;
using BidConReport.BidconAccess.Enteties.EstimationBuild.Sheets;
using BidConReport.BidconAccess.Enteties.QueryResults;
using BidConReport.BidconAccess.Enums;

namespace BidConReport.BidconAccess.Services.EstimationBuilding;
public class EstimationBuilder : IEstimationBuilder
{
    private readonly Dictionary<int, Func<EstimationSheetResult, EstimationBatch, ISheetItem?, ICollection<ATA>, ISheetItem>> _createSheetItemFunctionMap;
    private readonly ILayerdItemCalculator _layerdItemCalculator;

    public EstimationBuilder(ILayerdItemCalculator layerdItemCalculator)
    {
        _layerdItemCalculator = layerdItemCalculator;
        _createSheetItemFunctionMap = new()
        {
            { (int)RowType.Group, CreateGroup },
            { (int)RowType.Part, CreatePart },
            { (int)RowType.LayeredItem, CreateLayered },
            { (int)RowType.QuantityItem, CreateQuantity },
            { (int)RowType.LockedStageCollection, CreateLockedStage },
            { (int)RowType.Text, CreateText },
        };
    }
    public Estimation Build(EstimationBatch batch)
    {
        var netSheet = CreateSheetRoots(batch, SheetType.NetSheet).Single();
        var estimation = new Estimation
        {
            Name = batch.Estimation.Name,
            Description = batch.Estimation.Description,
            Customer = batch.Estimation.Customer,
            HandlingOfficer = batch.Estimation.HandlingOfficer,
            ConfirmationOfficer = batch.Estimation.ConfirmationOfficer,
            Place = batch.Estimation.Place,
            NetSheet = netSheet,
        };
        return estimation;
    }
    private IEnumerable<ISheetItem> CreateSheetRoots(EstimationBatch batch, SheetType sheetType)
    {
        Dictionary<int, ISheetItem> sheetItemMap = new();
        var atas = CreateATAs(batch).ToList();
        foreach (var sheetResult in batch.SheetResults.Where(x => x.SheetType == (int)sheetType).OrderBy(x => x.ParentRow).ThenBy(x => x.Position))
        {
            sheetItemMap.TryGetValue(sheetResult.ParentRow, out ISheetItem? parent);
            var item = _createSheetItemFunctionMap[sheetResult.RowType].Invoke(sheetResult, batch, parent, atas);
            sheetItemMap.Add(sheetResult.Row, item);
        }
        var roots = sheetItemMap.Values.Where(x => x.Parent is null);
        return roots;
    }

    private IEnumerable<ATA> CreateATAs(EstimationBatch batch)
    {
        foreach (var item in batch.ATAResults)
        {
            var additionalFactors = batch.ATAFactorResults
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.AdditionalExpensePercent / 100.0 + 1));
            var removalFactors = batch.ATAFactorResults
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.RemovalExpensePercent / 100.0 + 1));
            yield return new ATA()
            {
                PMATANum = item.PMATANum,
                Name = item.Name,
                Description = item.Description,
                AdditionalFactors = new(additionalFactors),
                RemovalFactors = new(removalFactors),
            };
        }
    }

    private static ISheetItem CreateGroup(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        var group = new Group
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
        };
        parent?.Children.Add(group);
        return group;
    }
    private static ISheetItem CreatePart(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        var item = new Part
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
            Unit = result.Unit,
        };
        parent?.Children.Add(item);
        return item;
    }
    private ISheetItem CreateLayered(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        Dictionary<int, double?> resourceCosts = _layerdItemCalculator.CalculateUnitCosts(result, batch);
        ATA? ata = atas.FirstOrDefault(x => x.PMATANum == result.PMATANum);
        var item = new Layered
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
            Unit = result.Unit,
            ResourceUnitCosts = resourceCosts,
            ATA = ata,
        };
        parent?.Children.Add(item);
        return item;
    }
    private ISheetItem CreateQuantity(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        var item = new QuantityItem
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
            Unit = result.Unit,
        };
        parent?.Children.Add(item);
        return item;
    }
    private ISheetItem CreateLockedStage(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        var item = new LockedStage
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
        };
        parent?.Children.Add(item);
        return item;
    }
    private ISheetItem CreateText(EstimationSheetResult result, EstimationBatch batch, ISheetItem? parent, ICollection<ATA> atas)
    {
        var item = new Text
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
        };
        parent?.Children.Add(item);
        return item;
    }
}
