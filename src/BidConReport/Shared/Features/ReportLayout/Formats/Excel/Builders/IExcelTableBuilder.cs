using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelTableBuilder
{
    void AddTable(IWorksheet sheet);
}