﻿using AppPlatform.Core.Enums.ViewTemplate;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetRowFormat : IViewEntity, IFormat
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public SheetRowType RowType { get; set; }
    [StringLength(50)]
    public string SheetSectionId { get; set; } = string.Empty;
    public SheetSection? SheetSection { get; set; }
    [StringLength(50)]
    public string? BackgroundColor { get; set; }
    [StringLength(50)]
    public string? TextColor { get; set; }
    public int FontSize { get; set; } = 12;
    public bool IsBold { get; set; } = false;
    public bool IsItalic { get; set; } = false;
    public bool IsUnderline { get; set; } = false;
    public Align? Align { get; set; }
    public Justify? Justify { get; set; }
    public TextFormatType FormatType { get; set; } = TextFormatType.Text;
    public bool HasThoasandsSeparator { get; set; } = true;
    public int DecimalCount { get; set; } = 2;
    public bool DoesIncludeTimeOfDay { get; set; } = false;
    public bool HasBorderLeft { get; set; } = false;
    public bool HasBorderTop { get; set; } = false;
    public bool HasBorderRight { get; set; } = false;
    public bool HasBorderBottom { get; set; } = false;
    public BorderStyle BorderStyle { get; set; } = BorderStyle.Solid;



    //[StringLength(50)]
    //public string? SheetColumnId { get; set; } = string.Empty;
    //public SheetColumn? SheetColumn { get; set; }
    //[StringLength(50)]
    //public string? DataCellId { get; set; } = string.Empty;
    //public DataCell? DataCell { get; set; }
}
