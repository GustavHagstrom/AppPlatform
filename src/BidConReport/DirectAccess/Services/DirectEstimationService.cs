using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;
using BidConReport.DirectAccess.Enums;

namespace BidConReport.DirectAccess.Services;
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
        var netSheet = CreateSheet(batch, SheetTypes.NetSheet);
        throw new NotImplementedException();
    }
    public async Task<IEnumerable<Estimation>> GetEstimationsAsync(IEnumerable<string> estimationIds)
    {
        var batches = await _queryService.GetEstimationBatchesAsync(estimationIds);
        throw new NotImplementedException();
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

        foreach (var item in batch.Sheet.Where(x => x.SheetType == (int)sheetType).OrderBy(x => x.Row))
        {
            var node = CreateSheetItem(item);
            map[item.Row] = node;
            if (map.ContainsKey(node.ParentRow))
            {
                var parent = map[node.ParentRow];
                node.Parent = parent;
                parent.SheetItems.Add(node);
            }
        }
        return map.First(x => x.Value.Parent is null).Value;
    }
    private double? SetCost(SheetItem item, EstimationBatch batch)
    {
        switch (item.LayerType)
        {
            case LayerType.None:
                foreach (var child in item.SheetItems)
                {
                    SetCost(child, batch);
                }
                item.UnitCost = item.SheetItems.Where(x => x.IsActive).Sum(x => x.TotalCost);
                item.TotalCost = item.UnitCost * (item.Quantity is null ? 1 : item.Quantity);
                break;
            case LayerType.WorkResult:
                item.UnitCost = GetWorkResultLayerCost(batch, item.LayerId);
                item.TotalCost = item.UnitCost * item.Quantity;
                break;
            case LayerType.DesignElement:
                if (item.Description == "Nedpendlat undertak med system av stålprofiler till undersida betongbjälklag")
                {
                    var a = 0;
                }
                item.UnitCost = GetDesignElementLayerCost(batch, item.LayerId);
                item.TotalCost = item.UnitCost * item.Quantity;
                break;
            case LayerType.MixedElement:
                item.UnitCost = GetMixedElementLayerCost(batch, item.LayerId);
                item.TotalCost = item.UnitCost * item.Quantity;
                break;
        }
        return item.TotalCost;
    }
    private double GetMixedElementLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        var layerItem = batch.MELayer.Where(x => x.Id == layerId && x.IsActive).ToList();
        foreach (var item in layerItem)
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
        var layerItem = batch.DELayer.Where(x => x.Id == layerId && x.IsActive).ToList();
        foreach (var item in layerItem)
        {
            var cost = GetWorkResultLayerCost(batch, item.LayerId);
            sum += cost * item.Cons;
        }
        return sum;
    }
    private double GetWorkResultLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        var layerItem = batch.WRLayer.Where(x => x.Id == layerId && x.IsActive).ToList();
        foreach (var item in layerItem)
        {
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
            LayerType = sheetResult.LayerType is not null ? (LayerType)sheetResult.LayerType : LayerType.None,
            RowType = (RowType)sheetResult.RowType,
            LayerId = sheetResult.LayerId,
            Quantity = sheetResult.Quantity,
        };
    }
}