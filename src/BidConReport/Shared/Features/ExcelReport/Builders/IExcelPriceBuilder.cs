using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelPriceBuilder
{
    void AddPrice(IWorksheet sheet);
}