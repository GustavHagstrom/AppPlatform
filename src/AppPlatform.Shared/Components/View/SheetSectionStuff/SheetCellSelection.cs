using AppPlatform.Core.Enteties.EstimationEnteties;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Shared.Components.View.SheetSectionStuff;

public record SheetCellSelection(SheetItem? Item, SheetColumnType ColumnType);
