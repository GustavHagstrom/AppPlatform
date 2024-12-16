using AppPlatform.Core.Models.EstimationView;

namespace AppPlatform.Shared.Services.Views;
public interface IViewStyleService
{
    string CreateFormatStyles(IFormat format);
    //string CreateSheetColumnStyles(SheetColumn column, int allColumnsWidthSum);
}