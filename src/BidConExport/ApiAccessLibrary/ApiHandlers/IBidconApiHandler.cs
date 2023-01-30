using SharedLibrary.Models;

namespace ApiAccessLibrary.ApiHandlers;
public interface IBidconApiHandler
{
    Task<SimpleEstimation> GetEstimationAsync(TokenModel tokenModel, string id, EstimationImportSettings settings);
    Task<IEnumerable<DbEstimation>> GetEstimationsAsync(TokenModel tokenModel);
    Task<DbFolder> GetFolderAsync(TokenModel tokenModel);
}