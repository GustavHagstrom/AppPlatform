﻿using AppPlatform.Shared.DTOs.EstimationView;
using AppPlatform.Core.Enums.ViewTemplate;

namespace AppPlatform.Tests.Server;
public static class EstimationViewTemplateDtoSamples
{
    public static EstimationViewTemplateDto Sample()
    {
        var entety = new EstimationViewTemplateDto
        {
            Name = "Test",
            DataSections =
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
                },
                new DataSectionTemplateDto
                {
                    Order = 3,
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
            SheetSections = new List<SheetSectionTemplateDto>
            {
                new SheetSectionTemplateDto
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
                },
                new SheetSectionTemplateDto
                {
                    Order = 4,
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
            }            
        };
        return entety;
    }
    public static IEnumerable<EstimationViewTemplateDto> ListSample => new List<EstimationViewTemplateDto> { Sample(), Sample() };
}
