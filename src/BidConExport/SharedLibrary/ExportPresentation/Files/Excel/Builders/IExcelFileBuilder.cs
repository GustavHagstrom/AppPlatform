using BidConReport.SharedLibrary.Models;
using SharedLibrary.ExportPresentation.Layout;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(SimpleEstimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
