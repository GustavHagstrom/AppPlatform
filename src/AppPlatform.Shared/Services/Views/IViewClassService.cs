using AppPlatform.Core.Enteties.EstimationView;

namespace AppPlatform.Shared.Services.Views;
public interface IViewClassService
{
    string CreateCellFormatClass(string name, CellFormat format);
    string CreateSheetColumnClass(string name, SheetColumn column, int allColumnsWidthSum);
}