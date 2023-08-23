using BidConReport.BidconDatabaseAccess.Enteties;
using BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
using BidConReport.BidconDatabaseAccess.Enums;

namespace BidConReport.BidconDatabaseAccess.Services;
public class DirectEstimationService : IDirectEstimationService
{
    private readonly IEstimationQueryService _queryService;

    public DirectEstimationService(IEstimationQueryService queryService)
    {
        _queryService = queryService;
    }
    public async Task<Estimation> GetEstimationAsync(string estimationId)
    {
        var batch = await _queryService.GetEstimationBatchAsync(estimationId);
        return BuildEstimation(batch);
    }
    public async Task<List<Estimation>> GetEstimationsAsync(IEnumerable<string> estimationIds)
    {
        var batches = await _queryService.GetEstimationBatchesAsync(estimationIds);
        var estimations = batches.Select(BuildEstimation);
        return estimations.ToList();
    }
    private Estimation BuildEstimation(EstimationBatch batch)
    {
        var netSheet = CreateSheet(batch, SheetTypes.NetSheet);
        var estimation = new Estimation
        {
            Name = batch.Estimation.Name,
            Description = batch.Estimation.Description,
            Customer = batch.Estimation.Customer,
            HandlingOfficer = batch.Estimation.HandlingOfficer,
            ConfirmationOfficer = batch.Estimation.ConfirmationOfficer,
            EstimationId = batch.Estimation.EstimationID,
            Place = batch.Estimation.Place,
            IsLocked = batch.Estimation.IsLocked,
            NetSheet = netSheet,
        };
        return estimation;
    }
    private SheetItem CreateSheet(EstimationBatch batch, SheetTypes sheetType)
    {
        var root = CreateSheetTree(batch, sheetType);
        SetCost(root, batch);
        return root;
    }
    private SheetItem CreateSheetTree(EstimationBatch batch, SheetTypes sheetType)
    {
        Dictionary<int, SheetItem> map = new Dictionary<int, SheetItem>();
        //var items = batch.Sheet.Where(x => x.SheetType == (int)sheetType && x.Version == batch.Estimation.CurrentVersion).OrderBy(x => x.Row);
        var items = batch.Sheet.Where(x => x.SheetType == (int)sheetType).OrderBy(x => x.Row);
        foreach (var item in items)
        {
            var node = CreateSheetItem(item);
            map[item.Row] = node;
            if (map.TryGetValue(node.ParentRow, out var parent))
            {
                node.Parent = parent;
                parent.SheetItems.Add(node);
            }
        }
        return map.Values.First(x => x.Parent is null);
    }
    private void SetCost(SheetItem item, EstimationBatch batch)
    {
        switch (item.RowType)
        {
            case (int)RowType.Group:
                foreach (var child in item.SheetItems)
                {
                    SetCost(child, batch);
                }
                item.TotalCost = item.SheetItems.Where(x => x.IsActive).Sum(x => x.TotalCost);
                break;
            case (int)RowType.Part:
                foreach (var child in item.SheetItems)
                {
                    SetCost(child, batch);
                }
                item.UnitCost = item.SheetItems.Where(x => x.IsActive).Sum(x => x.TotalCost);
                item.TotalCost = item.UnitCost * item.Quantity;
                break;
            case (int)RowType.LayeredItem:
                if (item.LayerType == (int)LayerType.MixedElement)
                {
                    item.UnitCost = GetMixedElementLayerCost(batch, item.LayerId);
                }
                else if(item.LayerType == (int)LayerType.DesignElement)
                {
                    item.UnitCost = GetDesignElementLayerCost(batch, item.LayerId);
                }
                else if (item.LayerType == (int)LayerType.WorkResult)
                {
                    item.UnitCost = GetWorkResultLayerCost(batch, item.LayerId);
                }
                else
                {
                    throw new InvalidOperationException("Unknown layertype");
                }
                item.TotalCost = item.UnitCost * item.Quantity;
                break;
        }
    }
    private double GetMixedElementLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        //var layerItems = batch.MELayer.Where(x => x.Id == layerId && x.IsActive && x.Version == batch.Estimation.CurrentVersion).ToList();
        var layerItems = batch.MELayer.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            if (item.LayerType == (int)LayerType.DesignElement)
            {
                var cost = GetDesignElementLayerCost(batch, item.LayerId);
                sum += cost * item.Cons;
            }
            else if (item.LayerType == (int)LayerType.WorkResult)
            {
                var cost = GetWorkResultLayerCost(batch, item.LayerId);
                sum += cost * item.Cons;
            }
        }
        return sum;
    }
    private double GetDesignElementLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        //var layerItems = batch.DELayer.Where(x => x.Id == layerId && x.IsActive && x.Version == batch.Estimation.CurrentVersion).ToList();
        var layerItems = batch.DELayer.Where(x => x.Id == layerId).ToList();
        foreach (var item in layerItems)
        {
            var cost = GetWorkResultLayerCost(batch, item.LayerId);
            sum += cost * item.Cons;
        }
        return sum;
    }
    private double GetWorkResultLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        //var layerItems = batch.WRLayer.Where(x => x.Id == layerId && x.IsActive && x.Version == batch.Estimation.CurrentVersion).ToList();
        var layerItems = batch.WRLayer.Where(x => x.Id == layerId && x.IsActive).ToList();
        foreach (var item in layerItems)
        {
            //var resource = batch.Resource.Single(x => x.Id == item.LayerId && x.Version == batch.Estimation.CurrentVersion);
            var resource = batch.Resource.Single(x => x.Id == item.LayerId);
            var cost = resource.Price * item.Cons * item.ConsFactor * (1 + (item.Waste / 100.0));
            sum += cost;
        }
        return sum;
    }
    private SheetItem CreateSheetItem(EstimationSheetResult sheetResult)
    {
        return new SheetItem
        {
            IsActive = sheetResult.IsActive,
            Description = sheetResult.Description,
            Row = sheetResult.Row,
            ParentRow = sheetResult.ParentRow,
            Remark = sheetResult.Remark,
            Unit = sheetResult.Unit,
            LayerType = sheetResult.LayerType,
            RowType = sheetResult.RowType,
            LayerId = sheetResult.LayerId,
            Quantity = sheetResult.Quantity,
        };
    }
}