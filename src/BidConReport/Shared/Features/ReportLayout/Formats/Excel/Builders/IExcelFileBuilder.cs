using BidConReport.Shared.Features.ReportLayout.Models;
using BidConReport.Shared.Models;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(Estimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
