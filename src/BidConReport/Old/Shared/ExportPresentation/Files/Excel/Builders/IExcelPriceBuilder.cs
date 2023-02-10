using Syncfusion.XlsIO;

namespace BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
public interface IExcelPriceBuilder
{
    void AddPrice(IWorksheet sheet);
}