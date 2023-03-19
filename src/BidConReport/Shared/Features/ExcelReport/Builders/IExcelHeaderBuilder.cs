using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelHeaderBuilder
{
    void AddHeader(IWorksheet sheet);
}