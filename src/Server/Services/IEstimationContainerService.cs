using SharedLibrary.DTOs;
using SharedLibrary.DTOs.BidconAccess;

namespace AppPlatform.Server.Services;
public interface IEstimationContainerService
{
    ICollection<BC_EstimationBatchDto> ImportedEstimations { get; set; }
}