namespace BidConReport.Shared.Models;
public class BidConImportResult<T>
{
    public required T Result { get; set; }
    public List<string> Messages { get; set; } = new();
}
