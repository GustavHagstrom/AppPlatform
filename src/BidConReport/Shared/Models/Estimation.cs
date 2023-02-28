using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Models;

public class Estimation
{
    //[BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    [MaxLength(50)]
    public required Guid Id { get; set; }
    [MaxLength(50)]
    public required string BidConId { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(50)]
    public string? Description { get; set; }
    [MaxLength(10)]
    public required string Currency { get; set; }
    public required double CostBeforeChanges { get; set; }
    public required DateTime CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public required ICollection<string> QuickTags { get; set; }
    public required ICollection<string> SelectionTags { get; set; }
    //public required QuickTag[] QuickTags { get; set; }
    //public required SelectionTag[] SelectionTags { get; set; }
    public required List<EstimationItem> Items { get; set; } = new();
    [NotMapped]
    public required List<LockedCategory> LockedCategories { get; set; } = new();

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