namespace BidConReport.Shared.Models;
public class BidConImportResult<T>
{
    public T? Result { get; set; }
    public string? ErrorMessage { get; set; }
}
