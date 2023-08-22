﻿using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class PriceSectionDto : IReportTemplateSectionDTO
{
    public int Id { get; set; }
    public int LayoutOrder { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool ShowChanges { get; set; } = true;
    [MaxLength(50)]
    public string PriceWithoutChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string ChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string PriceWithChangesDescription { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Comment { get; set; } = string.Empty;
    public int PriceFontId { get; set; }
    public FontPropertiesDto PriceFont { get; set; } = FontPropertiesDto.Default;
    public int CommentFontId { get; set; }
    public FontPropertiesDto CommentFont { get; set; } = FontPropertiesDto.Default;
}