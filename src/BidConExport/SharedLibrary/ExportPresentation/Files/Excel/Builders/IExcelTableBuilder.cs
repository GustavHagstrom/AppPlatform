using Syncfusion.XlsIO;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelTableBuilder
{
    void AddTable(IWorksheet sheet);
}