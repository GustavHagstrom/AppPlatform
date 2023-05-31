namespace BidConReport.Shared.Entities;
public class DbEstimation
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
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
