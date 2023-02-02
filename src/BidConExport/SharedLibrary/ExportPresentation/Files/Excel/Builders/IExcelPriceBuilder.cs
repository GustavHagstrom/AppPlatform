using Syncfusion.XlsIO;

namespace BidConReport.SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelPriceBuilder
{
    void AddPrice(IWorksheet sheet);
}