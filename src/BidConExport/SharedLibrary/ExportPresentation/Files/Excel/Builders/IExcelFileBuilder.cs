using SharedLibrary.ExportPresentation.Layout;
using SharedLibrary.Models;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(SimpleEstimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
