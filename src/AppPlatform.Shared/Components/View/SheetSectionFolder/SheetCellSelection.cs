﻿using AppPlatform.Core.Models.EstimationEnteties;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.SharedModule.Components.View.SheetSectionFolder;

public record SheetCellSelection(SheetItem? Item, SheetColumnType ColumnType);
