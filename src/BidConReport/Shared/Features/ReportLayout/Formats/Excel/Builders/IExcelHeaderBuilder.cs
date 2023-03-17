using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelHeaderBuilder
{
    void AddHeader(IWorksheet sheet);
}