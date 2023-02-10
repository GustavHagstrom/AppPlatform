using Syncfusion.XlsIO;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelGeneralInformationBuilder
{
    void AddGeneralInformation(IWorksheet sheet);
}