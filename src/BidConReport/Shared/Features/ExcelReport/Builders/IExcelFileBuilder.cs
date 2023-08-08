using BidConReport.Shared.Entities;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(Estimation estimation, Entities.ReportTemplate.ReportTemplate layoutDefinition, bool asPdf);
}
