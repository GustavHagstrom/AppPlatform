using AppPlatform.BidconBrowserModule.Models;
using AppPlatform.BidconDatabaseAccess;
using AppPlatform.BidconDatabaseAccess.Models;
using AppPlatform.Shared.Data;
using AppPlatform.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.BidconBrowserModule.Services;
internal class BidconBrowserAccesService(IEstimationQueryService DbQueryService, IDbContextFactory<ApplicationDbContext> DbContextFactory) : IBidconBrowserAccesService
{
    public async Task<TreeItem> GetTreeItemRootAsync(ClaimsPrincipal userClaims)
    {
        var context = await DbContextFactory.CreateDbContextAsync();
        var credentials = await context.BidconAccessCredentials.Where(x => x.TenantId == userClaims.GetTenantId()).FirstOrDefaultAsync();
        if(credentials == null)
        {
            throw new Exception("No credentials found for user");
        }
        if(credentials.UseDesktopBidconLink)
        {
            throw new Exception("Desktop bidcon link is not supported");
        }
        var folderbatch = await DbQueryService.GetFolderBatchAsync(userClaims);
        var folder = CreateFromBatch(folderbatch);
        return new TreeItem(folder);
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
    private EstimationInfo CreateEstimationInfo(BidconDatabaseAccess.Models.Estimation estimation)
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
