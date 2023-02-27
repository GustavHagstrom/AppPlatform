namespace BidConReport.Shared.Models;

public class Estimation
{
    //[BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    public string BidConId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public double CostBeforeChanges { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public required Tag[] QuickTags { get; set; }
    public required Tag[] SelectionTags { get; set; }
    public List<EstimationItem> Items { get; set; } = new();
    //[BsonIgnore]
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