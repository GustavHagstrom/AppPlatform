using AppPlatform.BidconDatabaseAccess.NewModels;
using AppPlatform.Core.Enteties.EstimationEnteties;

namespace AppPlatform.BidconDatabaseAccess.Services;
public interface IBidconAccess
{
    Task<Folder> GetFolderRootAsync();
    Task<Estimation> GetEstimation(string estimationId);

}
