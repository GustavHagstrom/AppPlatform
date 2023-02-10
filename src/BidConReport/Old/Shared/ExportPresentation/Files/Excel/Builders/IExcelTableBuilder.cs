using Syncfusion.XlsIO;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelTableBuilder
{
    void AddTable(IWorksheet sheet);
}