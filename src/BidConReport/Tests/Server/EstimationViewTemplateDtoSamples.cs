﻿using BidConReport.Shared.DTOs.EstimationView;
using BidConReport.Shared.Enums.ViewTemplate;

namespace BidconReport.Tests.Server;
public static class EstimationViewTemplateDtoSamples
{
    public static EstimationViewTemplateDto Sample()
    {
        var entety = new EstimationViewTemplateDto
        {
            Name = "Test",
            DataSectionTemplates =
            {
                new DataSectionTemplateDto
                {
                    Order = 1,
                    Columns =
                    {
                        new DataColumnDto
                        {
                            WidthPercent = 100,
                            Order = 1,
                        }
                    },
                    Cells =
                    {
                        new CellTemplateDto
                        {
                            Column = 1,
                            Format = new CellFormatDto
                            {
                                FontFamily = "Calibri"
                            }
                        }
                    },
                    RowCount = 1,
                }
            },
            HeaderOrFooters =
            {
                new HeaderOrFooterDto
                {
                    Position = HeaderOrFooterPosition.TopLeft,
                    Value = "TopLeft Header"
                }
            },
            NetSheetSectionTemplate = new NetSheetSectionTemplateDto
            {
                Order = 2,
                Columns =
                {
                    new SheetColumnDto
                    {
                        Order = 1,
                        ColumnType = SheetColumnType.Description,
                        CellFormat = new CellFormatDto
                        {
                            FontFamily = "Calibri"
                        }
                    }
                },
            }
        };
        return entety;
    }
    public static IEnumerable<EstimationViewTemplateDto> ListSample => new List<EstimationViewTemplateDto> { Sample(), Sample() };
}
