﻿using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Features.ReportLayout.Table;
public class ColumnDefinition
{
    public bool IsActive { get; set; }
    public ColumnDataSource DataSource { get; set; }
    public FontProperties TitleFont { get; set; } = DefaultTitleFont();
    public FontProperties GroupFont { get; set; } = DefaultGroupFont();
    public FontProperties PartFont { get; set; } = DefaultPartFont();
    public FontProperties CelleFont { get; set; } = DefaultCellFont();
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    [Range(1, 12)]
    public int Width { get; set; }



    private static FontProperties DefaultTitleFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 16;
        return font;
    }
    private static FontProperties DefaultGroupFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 20;
        return font;
    }
    private static FontProperties DefaultPartFont()
    {
        var font = FontProperties.Default;
        font.Bold = true;
        font.FontSize = 11;
        return font;
    }
    private static FontProperties DefaultCellFont()
    {
        var font = FontProperties.Default;
        font.Bold = false;
        font.FontSize = 11;
        return font;
    }

}
public enum ColumnDataSource
{
    RowNumber,
    Name,
    Unit,
    DisplayedUnit,
    Quantity,
    DisplayedQuantity,
    Comment,
}
