using AppPlatform.Core.Models.EstimationEnteties;
using AppPlatform.Core.Models.FromShared;

namespace AppPlatform.Core.Abstractions;
public interface IBidconAccess
{
    Task<Folder> GetFolderRootAsync(string tenantId);
    Task<Estimation> GetEstimationAsync(string estimationId, string tenantId);

}
