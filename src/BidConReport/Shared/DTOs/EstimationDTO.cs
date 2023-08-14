using SharedPlatformLibrary.Features.Placeholder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.DTOs;

public class EstimationDTO
{
    //Placeholder attribute values may not be changed as it will break existing ReportTemplates

    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string BidConId { get; set; }
    [MaxLength(50)]
    public required string OrganizationId { get; set; }
    [Placeholder("{Name}")]
    [MaxLength(50)]
    public required string Name { get; set; }
    [Placeholder("{Description}")]
    [MaxLength(50)]
    public string? Description { get; set; }
    [Placeholder("{Representative}")]
    [MaxLength(50)]
    public string? Representative { get; set; }
    [Placeholder("{Supervisor}")]
    [MaxLength(50)]
    public string? Supervisor { get; set; }
    [Placeholder("{Currency}")]
    [MaxLength(10)]
    public required string Currency { get; set; }
    [Placeholder("{CostBeforeChanges}")]
    public required double CostBeforeChanges { get; set; }
    [Placeholder("{CreationDate}")]
    public required DateTime CreationDate { get; set; }
    [Placeholder("{ExpirationDate}")]
    public DateTime? ExpirationDate { get; set; }
    [Placeholder("{PrintDate}")]
    public DateTime? PrintDate { get; set; }

    [MaxLength(50)]
    public string? HiddenUnitAndAmount { get; set; } = null;
    public required ICollection<string> QuickTags { get; set; }
    public required ICollection<string> SelectionTags { get; set; }
    public required ICollection<EstimationItemDTO> Items { get; set; }
    public required ICollection<LockedCategoryDTO> LockedCategories { get; set; }

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