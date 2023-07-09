using BidConReport.Shared.Features.ReportTemplate;
using BidConReport.Shared.Entities;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(Estimation estimation, ReportTemplate.ReportTemplate layoutDefinition, bool asPdf);
}
