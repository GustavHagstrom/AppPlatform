namespace BidConReport.Shared.Entities;
public class BidConImportResult<T>
{
    public T? Value { get; set; }
    public string? ErrorMessage { get; set; }
}
