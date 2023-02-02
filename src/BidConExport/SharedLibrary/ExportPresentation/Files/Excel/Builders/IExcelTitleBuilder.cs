using Syncfusion.XlsIO;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelTitleBuilder
{
    void AddTitle(IWorksheet sheet);
}