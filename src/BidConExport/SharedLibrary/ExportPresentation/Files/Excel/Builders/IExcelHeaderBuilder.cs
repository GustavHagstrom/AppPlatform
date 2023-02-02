using Syncfusion.XlsIO;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelHeaderBuilder
{
    void AddHeader(IWorksheet sheet);
}