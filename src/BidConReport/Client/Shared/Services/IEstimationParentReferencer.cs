using BidConReport.Shared.DTOs;

namespace BidConReport.Client.Shared.Services;
public interface IEstimationParentReferencer
{
    void SetAllParentReferences(EstimationDTO estimation);
}