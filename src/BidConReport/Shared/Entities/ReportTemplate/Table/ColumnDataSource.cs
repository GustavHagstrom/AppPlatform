namespace BidConReport.Shared.Entities.ReportTemplate.Table;

public enum ColumnDataSource
{
    RowNumber,
    Name,
    Unit,
    DisplayedUnit,
    Quantity,
    DisplayedQuantity,
    Comment,
    //If more are added, don't forget to also add them in the dictionary map in TableColumnsLIst.razor and also in TableSection.cs
}

