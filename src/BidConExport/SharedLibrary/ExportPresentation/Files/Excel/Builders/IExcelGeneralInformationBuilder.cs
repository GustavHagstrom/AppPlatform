using Syncfusion.XlsIO;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelGeneralInformationBuilder
{
    void AddGeneralInformation(IWorksheet sheet);
}