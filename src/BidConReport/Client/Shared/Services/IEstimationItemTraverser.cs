using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.Services;
public interface IEstimationItemTraverser
{
    EstimationItemDTO? FindItem(EstimationDTO estimation, int row);
    IEnumerable<EstimationItemDTO> GetAllEstimationItems(EstimationDTO estimation);
}