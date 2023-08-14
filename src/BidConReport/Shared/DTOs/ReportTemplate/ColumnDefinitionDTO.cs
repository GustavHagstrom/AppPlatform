using System.ComponentModel.DataAnnotations;
using BidConReport.Shared.Enums;

namespace BidConReport.Shared.DTOs.ReportTemplate;
public class ColumnDefinitionDTO
{
    public int Id { get; set; }
    public int TableSectionId { get; set; }
    public bool IsActive { get; set; }
    public ColumnDataSource DataSource { get; set; }
    [MaxLength(50)]
    public string ColumnHeader { get; set; } = string.Empty;
    /// <summary>
    /// Int represent the % of the width space for the columm to use
    /// </summary>
    [Range(1, 100)]
    public int Width { get; set; }
    public int Order { get; set; }

}

