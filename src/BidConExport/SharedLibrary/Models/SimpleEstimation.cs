using BidConReport.SharedLibrary.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BidConReport.SharedLibrary.Models;

public class SimpleEstimation
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string BidConId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public double CostBeforeChanges { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public string[] StyleTags { get; set; } = Array.Empty<string>();
    public string[] OptionTags { get; set; } = Array.Empty<string>();
    public List<SimpleEstimationItem> Items { get; set; } = new();
    [BsonIgnore]
    public List<LockedCategory> LockedCategories { get; set; } = new();

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