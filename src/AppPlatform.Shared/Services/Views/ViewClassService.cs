using AppPlatform.Core.Enteties.EstimationView;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Shared.Services.Views;
public class ViewClassService : IViewClassService
{
    /// <summary>
    /// Create a class for a cell format
    /// </summary>
    /// <param name="name"></param>
    /// <param name="format"></param>
    /// <returns></returns>
    public string CreateCellFormatClass(string name, CellFormat format)
    {
        var classString = $".{name} {{";
        AddCellFormatStyles(classString, format);
        classString += "}";
        return classString;
    }
    public string CreateSheetColumnClass(string name, SheetColumn column, int allColumnsWidthSum)
    {
        var classString = $".{name} {{";
        classString += $"width: {(double)column.Width / allColumnsWidthSum}%;";
        AddCellFormatStyles(classString, column.CellFormat ?? new CellFormat()); 
        classString += "}";
        return classString;
    }
    private void AddCellFormatStyles(string classString, CellFormat format)
    {
        AddColorStyles(classString, format);
        AddTextStyles(classString, format);
        AddBorderStyles(classString, format);

        //if (    format.Padding is not null)
        //{
        //    classString += $"padding: {format.Padding};";
        //}
        //if (format.Margin is not null)
        //{
        //    classString += $"margin: {format.Margin};";
        //}
    }

    private void AddBorderStyles(string classString, CellFormat format)
    {
        string borderStyle = GetBorderStyle(format.BorderStyle);
        if (format.HasBorderLeft)
        {
            classString += $"border-left: 1px {borderStyle} black;";
        }
        if (format.HasBorderTop)
        {
            classString += $"border-top: 1px {borderStyle} black;";
        }
        if (format.HasBorderRight)
        {
            classString += $"border-right: 1px {borderStyle} black;";
        }
        if (format.HasBorderBottom)
        {
            classString += $"border-bottom: 1px {borderStyle} black;";
        }
    }

    private void AddTextStyles(string classString, CellFormat format)
    {
        classString += $"font-size: {format.FontSize};";
        classString += $"font-family: {format.FontFamily};";
        classString += $"text-align: {GetAlign(format.Align)};";
        classString += $"justify-content: {GetJustify(format.Justify)};";

        if (format.IsBold)
        {
            classString += $"font-weight: 600;";
        }
        if (format.IsItalic)
        {
            classString += $"font-style: italic;";
        }
        if (format.IsUnderline)
        {
            classString += $"text-decoration: underline;";
        }
    }

    private void AddColorStyles(string classString, CellFormat format)
    {
        if (format.BackgroundColor is not null)
        {
            classString += $"background-color: {format.BackgroundColor};";
        }
        if (format.TextColor is not null)
        {
            classString += $"color: {format.TextColor};";
        }
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
            Justify.Top => "top",
            Justify.Center => "center",
            Justify.Bottom => "bottom",
            _ => "bottom"
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
