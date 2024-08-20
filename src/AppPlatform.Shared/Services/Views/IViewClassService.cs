using AppPlatform.Core.Enteties.EstimationView;

namespace AppPlatform.Shared.Services.Views;
public interface IViewClassService
{
    string CreateCellFormatStyles(string name, CellFormat format);
    string CreateSheetColumnStyles(string name, SheetColumn column, int allColumnsWidthSum);
}