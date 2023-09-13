﻿using BidConReport.Shared.Enums.ViewTemplate;

namespace BidConReport.Server.Enteties.EstimationView;

public class SheetColumn : IEstimationViewEntity
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public int WidthPercent { get; set; }
    public SheetColumnType ColumnType { get; set; }

    public required CellFormat CellFormat { get; set; }
    public Guid NetSheetSectionTemplateId { get; set; }
    public NetSheetSectionTemplate? NetSheetSectionTemplate { get; set; }
}