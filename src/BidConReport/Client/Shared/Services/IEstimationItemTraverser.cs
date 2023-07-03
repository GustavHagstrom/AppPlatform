using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;
public interface IEstimationItemTraverser
{
    EstimationItem? FindItem(Estimation estimation, int row);
    IEnumerable<EstimationItem> GetAllEstimationItemsItems(Estimation estimation);
}