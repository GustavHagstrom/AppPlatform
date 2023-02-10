using Syncfusion.XlsIO;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelHeaderBuilder
{
    void AddHeader(IWorksheet sheet);
}