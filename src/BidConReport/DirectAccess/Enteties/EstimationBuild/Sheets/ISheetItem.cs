﻿namespace BidConReport.BidconDatabaseAccess.Enteties.EstimationBuild.Sheets;

public interface ISheetItem
{
    string Description { get; set; }
    //bool IsActive { get; set; }
    //string LayerId { get; }
    //int? LayerType { get; }
    ISheetItem? Parent { get; }
    //int ParentRow { get; }
    double? Quantity { get; set; }
    //string? Remark { get; set; }
    //int Row { get; }
    //int RowType { get; }
    List<ISheetItem> Children { get; }
    string? Unit { get; }
    double? UnitCost { get; }
    double? TotalCost { get; }
}