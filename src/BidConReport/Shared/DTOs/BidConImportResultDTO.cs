namespace BidConReport.Shared.DTOs;
public class BidConImportResultDTO<T>
{
    public T? Value { get; set; }
    public string? ErrorMessage { get; set; }
}
