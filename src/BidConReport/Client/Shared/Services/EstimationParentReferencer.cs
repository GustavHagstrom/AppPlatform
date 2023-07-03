using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;

public class EstimationParentReferencer : IEstimationParentReferencer
{
    public void SetAllParentReferences(Estimation estimation)
    {
        SetAllParentReferences(estimation.Items);
    }
    private void SetAllParentReferences(ICollection<EstimationItem> items, EstimationItem? parent = null)
    {
        foreach (EstimationItem item in items)
        {
            item.Parent = parent;
            SetAllParentReferences(item.Items, item);
        }
    }
}
