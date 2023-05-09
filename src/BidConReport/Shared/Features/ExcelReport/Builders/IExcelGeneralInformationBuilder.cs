using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelGeneralInformationBuilder
{
    void AddGeneralInformation(IWorksheet sheet);
}