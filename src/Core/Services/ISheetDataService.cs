using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Core.Services;
public interface ISheetDataService
{
    string? GetColumnDataFromItem(SheetColumnType type, SheetItem item);
    string GetColumnName(SheetColumnType type);
    string GetRowTypeName(SheetRowType type);
}