using BidConReport.Shared.DTOs;
using BidConReport.Shared.DTOs.BidconAccess;

namespace BidConReport.Client.Shared.Services;
public interface IEstimationContainerService
{
    ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; }
}