using BidConReport.Shared.Models;
using SharedLibrary.ExportPresentation.Layout;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(SimpleEstimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
