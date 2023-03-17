using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelGeneralInformationBuilder
{
    void AddGeneralInformation(IWorksheet sheet);
}