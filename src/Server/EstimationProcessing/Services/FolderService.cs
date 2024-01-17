using AppPlatform.Server.EstimationProcessing.Models;
using SharedLibrary.DTOs.BidconAccess;

namespace AppPlatform.Server.EstimationProcessing.Services;
public class FolderService : IFolderService
{
    public Folder CreateFromBatch(BC_EstimationFolderBatch batch)
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

        foreach (var folder in batch.Folders.OrderBy(x => x.FolderNum))
        {
            var newFolder = CreateDbFolder(folder);
            map.Add(folder.FolderNum, newFolder);
            if (map.ContainsKey(folder.ParentNum))
            {
                map[folder.ParentNum].SubFolders.Add(newFolder);
            }
        }
        foreach (var estimation in batch.Estimations)
        {
            var newEstimation = CreateEstimationInfo(estimation);
            map[newEstimation.FolderNum].DbEstimations.Add(newEstimation);
        }

        return root;
    }
    private Folder CreateDbFolder(BC_EstimationFolderDto folder)
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
    private EstimationInfo CreateEstimationInfo(BC_EstimationDto estimation)
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
