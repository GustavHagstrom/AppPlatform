using BidConReport.Shared.DTOs;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

namespace BidConReport.Shared.Features.ExcelReport.Builders;
public class ExcelFileBuilder : IExcelFileBuilder
{
    private readonly IExcelHeaderBuilder _excelHeaderBuilder;
    private readonly IExcelTitleBuilder _excelTitleBuilder;
    private readonly IExcelGeneralInformationBuilder _excelGeneralInformationBuilder;
    private readonly IExcelPriceBuilder _excelPriceBuilder;
    private readonly IExcelTableBuilder _excelTableBuilder;

    public ExcelFileBuilder(
        IExcelHeaderBuilder excelHeaderBuilder,
        IExcelTitleBuilder excelTitleBuilder,
        IExcelGeneralInformationBuilder excelGeneralInformationBuilder,
        IExcelPriceBuilder excelPriceBuilder,
        IExcelTableBuilder excelTableBuilder)
    {
        _excelHeaderBuilder = excelHeaderBuilder;
        _excelTitleBuilder = excelTitleBuilder;
        _excelGeneralInformationBuilder = excelGeneralInformationBuilder;
        _excelPriceBuilder = excelPriceBuilder;
        _excelTableBuilder = excelTableBuilder;
    }
    public byte[] BuildFile(EstimationDTO estimation, DTOs.ReportTemplate.ReportTemplateDTO layoutDefinition, bool asPdf)
    {
        using (ExcelEngine engine = new ExcelEngine())

        {
            var app = engine.Excel;
            app.DefaultVersion = ExcelVersion.Xlsx;
            var wb = app.Workbooks.Create(1);
            var sheet = wb.Worksheets[0];
            AddContent(estimation, layoutDefinition, sheet);
            return CreateFileBytes(wb, asPdf);
        }
    }

    private byte[] CreateFileBytes(IWorkbook wb, bool asPdf)
    {
        using (var stream = new MemoryStream())
        {
            if (asPdf)
            {
                wb.SaveAs(stream);
            }
            else
            {
                var renderer = new XlsIORenderer();
                var pdf = renderer.ConvertToPDF(wb.Worksheets[0]);
                pdf.Save(stream);
            }
            return stream.ToArray();
        }

    }

    private void AddContent(EstimationDTO estimation, DTOs.ReportTemplate.ReportTemplateDTO layoutDefinition, IWorksheet sheet)
    {
        //_excelHeaderBuilder.AddHeader(sheet);
        //foreach (var sectionType in layoutDefinition.Sections)
        //{
        //    switch (sectionType)
        //    {
        //        case LayoutSectionType.Title:
        //            _excelTitleBuilder.AddTitle(sheet);
        //            break;
        //        case LayoutSectionType.GeneralInformation:
        //            _excelGeneralInformationBuilder.AddGeneralInformation(sheet);
        //            break;
        //        case LayoutSectionType.Price:
        //            _excelPriceBuilder.AddPrice(sheet);
        //            break;
        //        case LayoutSectionType.Table:
        //            _excelTableBuilder.AddTable(sheet);
        //            break;
        //    }
        //}
    }
}
