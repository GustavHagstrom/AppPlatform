using Syncfusion.XlsIO;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelTableBuilder
{
    void AddTable(IWorksheet sheet);
}