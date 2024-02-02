using AppPlatform.Server.EstimationProcessing.Calculations;
using AppPlatform.Server.EstimationProcessing.Models;
using AppPlatform.Core.Enums.BidconAccess;
using AppPlatform.BidconDataAccess.Models;

namespace AppPlatform.Server.EstimationProcessing.Services;
public class EstimationBuilderService : IEstimationBuilderService
{
    private readonly Dictionary<int, Func<BC_EstimationSheet, BC_EstimationBatch, ISheetItem?, ICollection<Models.ATA>, ISheetItem>> _createSheetItemFunctionMap;
    private readonly ILayerdItemCalculator _layerdItemCalculator = new LayerdItemCalculator();

    public EstimationBuilderService()
    {
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
    public Estimation Build(BC_EstimationBatch batch)
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
            TenderTotal = GetTenderTotal(batch),
        };
        return estimation;
    }

    private double? GetTenderTotal(BC_EstimationBatch batch)
    {
        int tenderType = batch.Estimation.TenderType;
        bool isValidTenderType = tenderType != (int)TenderType.None && tenderType != (int)TenderType.Unspecified;

        return isValidTenderType ? batch.Estimation.TenderTotal : null;
    }

    private IEnumerable<ISheetItem> CreateSheetRoots(BC_EstimationBatch batch, SheetType sheetType)
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

    private IEnumerable<ATA> CreateATAs(BC_EstimationBatch batch)
    {
        foreach (var item in batch.ATAs)
        {
            var additionalFactors = batch.ATAFactors
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.AdditionalExpensePercent / 100.0 + 1));
            var removalFactors = batch.ATAFactors
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.RemovalExpensePercent / 100.0 + 1));
            var additionalAskingFactors = batch.ATAFactors
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.AdditionalPercent / 100.0 + 1));
            var removalAskingFactors = batch.ATAFactors
                .Where(x => x.PMATANum == item.PMATANum)
                .Select(x => new KeyValuePair<int, double>(x.ResourceType, x.RemovalPercent / 100.0 + 1));
            yield return new Models.ATA()
            {
                PMATANum = item.PMATANum,
                Name = item.Name,
                Description = item.Description,
                AdditionalExpenseFactors = new(additionalFactors),
                RemovalExpenseFactors = new(removalFactors),
                AdditionalAskingFactors = new(additionalAskingFactors),
                RemovalAskingFactors = new Dictionary<int, double>(removalAskingFactors),
            };
        }
    }

    private static ISheetItem CreateGroup(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
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
    private static ISheetItem CreatePart(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
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
    private ISheetItem CreateLayered(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
    {
        Dictionary<int, double?> resourceCosts = _layerdItemCalculator.CalculateUnitCosts(result, batch);
        Models.ATA? ata = atas.FirstOrDefault(x => x.PMATANum == result.PMATANum);
        var item = new Layered
        {
            Description = result.Description,
            Parent = parent,
            Quantity = result.Quantity,
            Unit = result.Unit,
            ResourceUnitCosts = resourceCosts,
            ATA = ata,
            AskingPriceFactors = new Dictionary<int, double>(batch.ResourceFactors.Select(x => new KeyValuePair<int, double>(x.ResourceType, x.Factor))),
            AddedInPhase = result.AddedInPhase,
            TenderType = batch.Estimation.TenderType,
            ManualAskingUnitPrice = result.UnitPriceManual,
        };
        parent?.Children.Add(item);
        return item;
    }
    private ISheetItem CreateQuantity(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
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
    private ISheetItem CreateLockedStage(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
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
    private ISheetItem CreateText(BC_EstimationSheet result, BC_EstimationBatch batch, ISheetItem? parent, ICollection<Models.ATA> atas)
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
