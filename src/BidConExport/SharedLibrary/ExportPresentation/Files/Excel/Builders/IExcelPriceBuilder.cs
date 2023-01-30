using Syncfusion.XlsIO;

namespace SharedLibrary.ExportPresentation.Files.Excel.Builders;
public interface IExcelPriceBuilder
{
    void AddPrice(IWorksheet sheet);
}