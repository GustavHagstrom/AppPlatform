using BidConReport.Shared.Entities;

namespace BidConReport.Client.Shared.Services;
public interface IEstimationParentReferencer
{
    void SetAllParentReferences(Estimation estimation);
}