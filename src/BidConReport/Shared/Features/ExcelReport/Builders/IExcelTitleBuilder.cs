using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public interface IExcelTitleBuilder
{
    void AddTitle(IWorksheet sheet);
}