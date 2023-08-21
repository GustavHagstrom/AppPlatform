using BidConReport.DirectAccess.Enteties;
using BidConReport.DirectAccess.Enteties.QueryResults;
using Syncfusion.DocIO.DLS;

namespace BidConReport.DirectAccess.Services;
public class DbFolderService : IDbFolderService
{
    public DbFolder CreateFromBatch(EstimationFolderBatch batch)
    {
        Dictionary<int, DbFolder> map = new();
        var root = new DbFolder
        {
            SubFolders = new List<DbFolder>(),
            DbEstimations = new List<DbEstimation>(),
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
            var newEstimation = CreateDbEstimation(estimation);
            map[newEstimation.FolderNum].DbEstimations.Add(newEstimation);
        }

        return root;
    }
    private DbFolder CreateDbFolder(EstimationFolderResult folder)
    {
        return new DbFolder
        {
            FolderNum = folder.FolderNum,
            ParentNum = folder.ParentNum,
            SubFolders = new List<DbFolder>(),
            DbEstimations = new List<DbEstimation>(),
            Name = folder.Name,
        };
    }
    private DbEstimation CreateDbEstimation(EstimationResult estimation)
    {
        return new DbEstimation
        {
            Name = estimation.Name,
            Description = estimation.Description,
            FolderNum = estimation.FolderNum,
            Id = estimation.EstimationID.ToString(),
        };
    }
}
