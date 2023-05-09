using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelTableBuilder
{
    void AddTable(IWorksheet sheet);
}