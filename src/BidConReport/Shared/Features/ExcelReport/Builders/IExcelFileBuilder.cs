using BidConReport.Shared.DTOs;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelFileBuilder
{
    byte[] BuildFile(EstimationDTO estimation, DTOs.ReportTemplate.ReportTemplateDto layoutDefinition, bool asPdf);
}
