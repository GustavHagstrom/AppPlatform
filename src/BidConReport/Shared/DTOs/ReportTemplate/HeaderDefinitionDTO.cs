﻿using BidConReport.Shared.DTOs.ReportTemplate;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class HeaderDefinitionDto
{
    public int Id { get; set; }
    public int FontId { get; set; }
    public FontPropertiesDto Font { get; set; } = FontPropertiesDto.Default;
    /// <summary>
    /// Text within curly bracers {} will try to find matching dtat form estimation info
    /// </summary>
    public string ValueCode { get; set; } = string.Empty;
}


