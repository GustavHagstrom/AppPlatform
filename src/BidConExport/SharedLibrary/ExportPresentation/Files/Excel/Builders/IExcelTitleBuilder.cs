using Syncfusion.XlsIO;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelTitleBuilder
{
    void AddTitle(IWorksheet sheet);
}