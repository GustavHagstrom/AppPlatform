using BidConReport.Shared.Models;
using SharedLibrary.ExportPresentation.Layout;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(Estimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
