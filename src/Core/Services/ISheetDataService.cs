using AppPlatform.Core.Models.EstimationEnteties;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Core.Services;
public interface ISheetDataService
{
    string? GetColumnDataFromItem(SheetColumnType type, SheetItem item);
    string GetColumnTypeName(SheetColumnType type);
    string GetRowTypeName(SheetRowType type);
}