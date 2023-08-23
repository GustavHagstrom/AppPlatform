namespace BidConReport.BidconDatabaseAccess.Enteties.QueryResults;
public class ResourceFactorResult
{
    public Guid EstimationId { get; set; }
    public required int ResourceType { get; set; }
    public required double Factor { get; set; }
}
