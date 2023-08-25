namespace BidConReport.BidconAccess.Enteties.EstimationBuild;
public class ATA
{
    public required int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Dictionary<int, double> AdditionalFactors { get; set; }
    public required Dictionary<int, double> RemovalFactors { get; set; }
}
