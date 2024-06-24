﻿using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class CellFormat : IViewEntity
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public string FontFamily { get; set; } = string.Empty;
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
    public BorderStyle BorderStyle { get; set; }



    //[StringLength(50)]
    //public string? SheetColumnId { get; set; } = string.Empty;
    //public SheetColumn? SheetColumn { get; set; }
    //[StringLength(50)]
    //public string? DataCellId { get; set; } = string.Empty;
    //public DataCell? DataCell { get; set; }
}
