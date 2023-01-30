using Syncfusion.XlsIO;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelHeaderBuilder
{
    void AddHeader(IWorksheet sheet);
}