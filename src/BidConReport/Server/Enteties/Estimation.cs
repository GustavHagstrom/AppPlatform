using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Server.Enteties;

public class Estimation
{
    //Placeholder attribute values may not be changed as it will break existing ReportTemplates

    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string BidConId { get; set; }
    public int OrganizationId { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(50)]
    public string? Description { get; set; }
    public string? Representative { get; set; }
    [MaxLength(50)]
    public string? Supervisor { get; set; }
    [MaxLength(10)]
    public required string Currency { get; set; }
    public required double CostBeforeChanges { get; set; }
    public required DateTime CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    [NotMapped]
    public DateTime? PrintDate { get; set; }

    [MaxLength(50)]
    public string? HiddenUnitAndAmount { get; set; } = null;
    public required ICollection<string> QuickTags { get; set; }
    public required ICollection<string> SelectionTags { get; set; }
    public required ICollection<EstimationItem> Items { get; set; }

    public override string ToString()
    {
        if (string.IsNullOrEmpty(Description))
        {
            return $"{Name}";
        }
        else
        {
            return $"{Name} - {Description}";
        }
    }
}