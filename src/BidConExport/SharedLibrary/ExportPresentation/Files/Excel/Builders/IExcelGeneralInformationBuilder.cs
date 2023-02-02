using Syncfusion.XlsIO;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelGeneralInformationBuilder
{
    void AddGeneralInformation(IWorksheet sheet);
}