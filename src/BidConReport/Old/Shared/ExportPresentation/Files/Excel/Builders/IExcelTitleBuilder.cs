using Syncfusion.XlsIO;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelTitleBuilder
{
    void AddTitle(IWorksheet sheet);
}