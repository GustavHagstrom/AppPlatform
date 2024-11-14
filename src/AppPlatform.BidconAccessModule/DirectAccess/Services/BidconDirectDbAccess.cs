using AppPlatform.BidconAccessModule.DirectAccess.Models;
using AppPlatform.Shared.Abstractions;
using AppPlatform.Shared.Models;
using System.Security.Claims;

namespace AppPlatform.BidconAccessModule.DirectAccess.Services;
internal class BidconDirectDbAccess : IBidconAccess
{
    private readonly IEstimationQueryService _estimationQuery;

    public BidconDirectDbAccess(IEstimationQueryService estimationQuery)
    {
        _estimationQuery = estimationQuery;
    }
    public Task<Core.Enteties.EstimationEnteties.Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims)
    {
        throw new NotImplementedException();
    }

    public async Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims)
    {
        var folderBatch = await _estimationQuery.GetFolderBatchAsync(userClaims);
        var folder = CreateFromBatch(folderBatch);
        return folder;
    }
    private Folder CreateFromBatch(EstimationFolderBatch batch)
    {
        Dictionary<int, Folder> map = new();
        var root = new Folder
        {
            SubFolders = new List<Folder>(),
            DbEstimations = new List<EstimationInfo>(),
            FolderNum = -1,
            Name = "Root",
            ParentNum = -2,
        };
        map.Add(root.FolderNum, root);

        foreach (var folder in batch.Folders)
        {
            var newFolder = CreateDbFolder(folder);
            map.Add(folder.FolderNum, newFolder);
        }
        foreach (var folder in map.Values)
        {
            if (map.ContainsKey(folder.ParentNum))
            {
                map[folder.ParentNum].SubFolders.Add(folder);
            }
        }
        foreach (var estimation in batch.Estimations)
        {
            var newEstimation = CreateEstimationInfo(estimation);
            map[newEstimation.FolderNum].DbEstimations.Add(newEstimation);
        }

        return root;
    }
    private Folder CreateDbFolder(EstimationFolder folder)
    {
        return new Folder
        {
            FolderNum = folder.FolderNum,
            ParentNum = folder.ParentNum,
            SubFolders = new List<Folder>(),
            DbEstimations = new List<EstimationInfo>(),
            Name = folder.Name,
        };
    }
    private EstimationInfo CreateEstimationInfo(Models.B_Estimation estimation)
    {
        return new EstimationInfo
        {
            Name = estimation.Name,
            Description = estimation.Description,
            FolderNum = estimation.FolderNum,
            Id = estimation.EstimationID.ToString(),
        };
    }
}
