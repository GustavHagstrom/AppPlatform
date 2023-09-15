using SharedLibrary.DTOs;
using SharedLibrary.DTOs.BidconAccess;

namespace Client.Shared.Services;
public interface IEstimationContainerService
{
    ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; }
}