using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Core.Enums.ViewTemplate;
using System.Globalization;

namespace AppPlatform.Shared.Services.Views;
public class ViewClassService : IViewClassService
{
    /// <summary>
    /// Create a class for a cell format
    /// </summary>
    /// <param name="name"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public string CreateCellFormatStyles(string name, CellFormat format)
    {
        //var classString = $".{name} {{";
        string classString = CreateCellFormatStyles(format);
        //classString += "}";
        return classString;
    }
    public string CreateSheetColumnStyles(string name, SheetColumn column, int allColumnsWidthSum)
    {
        //var classString = $".{name} {{";
        var classString = $"width: {((double)column.Width / allColumnsWidthSum * 100).ToString(CultureInfo.InvariantCulture)}% !important;\n";
        classString += CreateCellFormatStyles(column.CellFormat ?? new CellFormat()); 
      /*  classString += "}"*/;
        return classString;
    }
    private string CreateCellFormatStyles(CellFormat format)
    {
        var classString = string.Empty;
        classString += CreateColorStyles(format);
        classString +=  CreateTextStyles(format);
        classString += CreateBorderStyles(format);

        //if (    format.Padding is not null)
        //{
        //    classString += $"padding: {format.Padding};";
        //}
        //if (format.Margin is not null)
        //{
        //    classString += $"margin: {format.Margin};";
        //}
        return classString;
    }

    private string CreateBorderStyles(CellFormat format)
    {
        string classString = string.Empty;
        string borderStyle = GetBorderStyle(format.BorderStyle);
        if (format.HasBorderLeft)
        {
            classString += $"border-left: 1px {borderStyle} black !important;\n";
        }
        if (format.HasBorderTop)
        {
            classString += $"border-top: 1px {borderStyle} black !important;\n";
        }
        if (format.HasBorderRight)
        {
            classString += $"border-right: 1px {borderStyle} black !important;\n";
        }
        if (format.HasBorderBottom)
        {
            classString += $"border-bottom: 1px {borderStyle} black !important;\n";
        }
        return classString;
    }

    private string CreateTextStyles(CellFormat format)
    {
        var classString = $"font-size: {format.FontSize}px !important;\n";
        classString += $"font-family: {format.FontFamily} !important;\n";
        classString += $"text-align: {GetAlign(format.Align)} !important;\n";
        classString += $"justify-content: {GetJustify(format.Justify)} !important;\n";

        if (format.IsBold)
        {
            classString += $"font-weight: 600 !important;\n";
        }
        if (format.IsItalic)
        {
            classString += $"font-style: italic !important;\n";
        }
        if (format.IsUnderline)
        {
            classString += $"text-decoration: underline !important;\n";
        }
        return classString;
    }

    private string CreateColorStyles(CellFormat format)
    {
        string classString = string.Empty;
        if (format.BackgroundColor is not null)
        {
            classString += $"background-color: {format.BackgroundColor} !important;\n";
        }
        if (format.TextColor is not null)
        {
            classString += $"color: {format.TextColor} !important;\n";
        }
        return classString;
    }
    private string GetAlign(Align align)
    {
        return align switch
        {
            Align.Left => "left",
            Align.Center => "center",
            Align.Right => "right",
            _ => "left"
        };
    }
    private string GetJustify(Justify justify)
    {
        return justify switch
        {
            Justify.Top => "start",
            Justify.Center => "center",
            Justify.Bottom => "end",
            _ => "end"
        };
    }
    private string GetBorderStyle(BorderStyle style)
    {
        return style switch
        {
            BorderStyle.Solid => "solid",
            BorderStyle.Dashed => "dashed",
            BorderStyle.Dotted => "dotted",
            BorderStyle.Double => "double",
            _ => "solid"
        };
    }

}
