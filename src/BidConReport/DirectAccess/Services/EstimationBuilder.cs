﻿using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.EstimationBuild;
using BidConReport.DirectAccess.Enteties.EstimationBuild.SheetItems;
using BidConReport.DirectAccess.Enteties.QueryResults;
using BidConReport.DirectAccess.Enums;

namespace BidConReport.DirectAccess.Services;
public class EstimationBuilder
{
    public Estimation Build(EstimationBatch batch)
    {
        var netSheet = CreateSheet(batch, SheetTypes.NetSheet);
        throw new NotImplementedException();
        //var map = new Dictionary<int, EstimationSheetResult>(batch.Sheet.Select(item => new KeyValuePair<int, EstimationSheetResult>(item.Row, item)));
    }
    //private SheetItem CreateSheetRoot(EstimationBatch batch, SheetTypes sheetType)
    //{
    //    //var root = CreateSheetTree(batch, batch.Sheet.First(x => x.SheetType == (int)sheetType && x.ParentRow < 0));
    //    var netSheet = CreateSheetTreeMap(batch, SheetTypes.NetSheet);
    //}

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
            //if (!map.ContainsKey(item.Row))
            //{
            //    map[item.Row] = CreateSheetItem(item);
            //}

            //if (item.ParentRow > 0 && map.ContainsKey(item.ParentRow))
            //{
            //    SheetItem parent = map[item.ParentRow];
            //    SheetItem child = map[item.Row];

            //    parent.SheetItems.Add(child);
            //    child.Parent = parent;
            //}
        }

        // Find the root node
        return map.First(x => x.Value.Parent is null).Value;

        //return map.First(x => x.Value.ParentRow < 0).Value;
    }
    private void SetCost(SheetItem item, EstimationBatch batch)
    {
        switch (item.LayerType)
        {
            case LayerType.None:
                foreach (var child in item.SheetItems)
                {
                    SetCost(child, batch);
                }
                var childCostSum = item.SheetItems.Sum(x => x.Quantity is null ? x.UnitCost * 1 : x.UnitCost * x.Quantity);
                item.UnitCost = childCostSum;
                break;
            case LayerType.WorkResult:
                item.UnitCost = GetWorkResultLayerCost(batch, item.LayerId);
                break;
            case LayerType.DesignElement:
                item.UnitCost = GetDesignElementLayerCost(batch, item.LayerId);
                break;
            case LayerType.MixedElement:
                item.UnitCost = GetMixedElementLayerCost(batch, item.LayerId);
                break;
        }
    }
    private double GetMixedElementLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        var layerItem = batch.MELayer.Where(x => x.Id == layerId);
        foreach (var item in layerItem)
        {
            if (item.LayerType == (int)LayerType.DesignElement)
            {
                sum += GetDesignElementLayerCost(batch, item.LayerId) * item.Cons;
            }
            else if(item.LayerType == (int)LayerType.WorkResult)
            {
                sum += GetWorkResultLayerCost(batch, item.LayerId) * item.Cons;
            }
        }
        return sum;
    }
    private double GetDesignElementLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        var layerItem = batch.DELayer.Where(x => x.Id == layerId);
        foreach (var item in layerItem)
        {
            sum += GetWorkResultLayerCost(batch, item.LayerId) * item.Cons;
        }
        return sum;
    }
    private double GetWorkResultLayerCost(EstimationBatch batch, string layerId)
    {
        double sum = 0;
        var layerItem = batch.WRLayer.Where(x => x.Id == layerId);
        foreach (var item in layerItem)
        {
            sum += batch.Resource.Single(x => x.Id == item.LayerId).Price * item.Cons * item.ConsFactor * (1 + (item.Waste / 100));
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