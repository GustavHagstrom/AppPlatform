﻿using BidConReport.Shared.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace BidConReport.Server.Enteties.EstimationView;

public class CellFormat : IEstimationViewEntity
{
    public Guid Id { get; set; }
    [StringLength(50)]
    public required string FontFamily { get; set; }
    public int FontSize { get; set; }
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public Align Align { get; set; }
    public Justify Justify { get; set; }
    public TextFormatType FormatType { get; set; }
    public bool ThoasandsSeparator { get; set; }
    public int DecimalCount { get; set; }
    public bool IncludeTimeOfDay { get; set; }
    public bool BorderLeft { get; set; }
    public bool BorderTop { get; set; }
    public bool BorderRight { get; set; }
    public bool BorderBottom { get; set; }
    public BorderStyle Style { get; set; }



    public Guid? SheetColumnId { get; set; }
    public SheetColumn? SheetColumn { get; set; }
    public Guid? CellTemplateId { get; set; }
    public CellTemplate? CellTemplate { get; set; }
}
