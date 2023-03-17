using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelPriceBuilder
{
    void AddPrice(IWorksheet sheet);
}