using BidConReport.Shared.Features.ReportLayout;
using BidConReport.Shared.Models;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(Estimation estimation, LayoutDefinition layoutDefinition, bool asPdf);
}
