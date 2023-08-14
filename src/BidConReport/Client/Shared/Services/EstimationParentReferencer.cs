using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.Services;

public class EstimationParentReferencer : IEstimationParentReferencer
{
    public void SetAllParentReferences(EstimationDTO estimation)
    {
        SetAllParentReferences(estimation.Items);
    }
    private void SetAllParentReferences(ICollection<EstimationItemDTO> items, EstimationItemDTO? parent = null)
    {
        foreach (EstimationItemDTO item in items)
        {
            item.Parent = parent;
            SetAllParentReferences(item.Items, item);
        }
    }
}
