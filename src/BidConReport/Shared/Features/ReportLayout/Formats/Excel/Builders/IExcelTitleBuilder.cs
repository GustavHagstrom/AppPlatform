using Syncfusion.XlsIO;

namespace BidConReport.Shared.Features.ReportLayout.Formats.Excel.Builders;
public interface IExcelTitleBuilder
{
    void AddTitle(IWorksheet sheet);
}