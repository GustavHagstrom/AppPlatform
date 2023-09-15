namespace Client.Shared.EstimationProcessing.Models;
public class ATA
{
    public required int PMATANum { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required Dictionary<int, double> AdditionalExpenseFactors { get; set; }
    public required Dictionary<int, double> RemovalExpenseFactors { get; set; }
    public required Dictionary<int, double> AdditionalAskingFactors { get; set; }
    public required Dictionary<int, double> RemovalAskingFactors { get; set; }
}
