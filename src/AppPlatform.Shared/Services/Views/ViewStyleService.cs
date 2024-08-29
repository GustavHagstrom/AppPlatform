using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Core.Enums.ViewTemplate;
using System.Globalization;

namespace AppPlatform.Shared.Services.Views;
public class ViewStyleService : IViewStyleService
{
    public string CreateSheetColumnStyles(SheetColumn column, int allColumnsWidthSum)
    {
        //var classString = $".{name} {{";
        var classString = $"width: {((double)column.Width / allColumnsWidthSum * 100).ToString(CultureInfo.InvariantCulture)}%;\n";
        classString += CreateFormatStyles(column); 
      /*  classString += "}"*/;
        return classString;
    }
    public string CreateFormatStyles(IFormat format)
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

    private string CreateBorderStyles(IFormat format)
    {
        string classString = string.Empty;
        string borderStyle = GetBorderStyle(format.BorderStyle);
        if (format.HasBorderLeft)
        {
            classString += $"border-left: 1px {borderStyle} black;\n";
        }
        if (format.HasBorderTop)
        {
            classString += $"border-top: 1px {borderStyle} black;\n";
        }
        if (format.HasBorderRight)
        {
            classString += $"border-right: 1px {borderStyle} black;\n";
        }
        if (format.HasBorderBottom)
        {
            classString += $"border-bottom: 1px {borderStyle} black;\n";
        }
        return classString;
    }

    private string CreateTextStyles(IFormat format)
    {
        var classString = $"font-size: {format.FontSize}px;\n";
        //classString += $"font-family: {format.FontFamily};\n";
        classString += format.Align is null ? "" : $"text-align: {GetAlign(format.Align.Value)};\n";
        classString += format.Justify is null ? "" : $"align-items: {GetJustify(format.Justify.Value)};\n";

        if (format.IsBold)
        {
            classString += $"font-weight: 600;\n";
        }
        if (format.IsItalic)
        {
            classString += $"font-style: italic;\n";
        }
        if (format.IsUnderline)
        {
            classString += $"text-decoration: underline;\n";
        }
        return classString;
    }

    private string CreateColorStyles(IFormat format)
    {
        string classString = string.Empty;
        if (format.BackgroundColor is not null)
        {
            classString += $"background-color: {format.BackgroundColor};\n";
        }
        if (format.TextColor is not null)
        {
            classString += $"color: {format.TextColor};\n";
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
