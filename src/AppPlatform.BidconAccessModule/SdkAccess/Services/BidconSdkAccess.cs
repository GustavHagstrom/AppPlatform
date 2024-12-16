using AppPlatform.Core.Models.EstimationEnteties;
using AppPlatform.Core.Abstractions;
using BidCon.SDK.Database;
using System.Security.Claims;
using AppPlatform.Core.Models.FromShared;

namespace AppPlatform.BidconAccessModule.SdkAccess.Services;
internal class BidconSdkAccess : IBidconAccess
{
    private readonly DatabaseUser? _user = null;
    private readonly ISdkCredentialsService _sdkCredentialsService;

    private async Task<DatabaseUser> LazyUserAsync(ClaimsPrincipal userClaims)
    {
        if (_user is not null) return _user;
        var credentials = await _sdkCredentialsService.GetSdkCredentialsAsync(userClaims);

        if (credentials is null) throw new ArgumentNullException("No credentials found");

        var app = BidCon.SDK.Activator.CreateApp();
        app.InitConnectionFromConfig(credentials.ConfigPath);
        var user = await Task.Run(() =>app.Login(credentials.User, credentials.Password));
        return user;
    }
    public BidconSdkAccess(ISdkCredentialsService sdkCredentialsService)
    {
        _sdkCredentialsService = sdkCredentialsService;
    }

    public async Task<Estimation> GetEstimation(string estimationId, ClaimsPrincipal userClaims)
    {
        var user = await LazyUserAsync(userClaims);
        var bEstimation = user.ReadEstimation(estimationId);
        throw new NotImplementedException();
    }

    public async Task<Folder> GetFolderRootAsync(ClaimsPrincipal userClaims)
    {
        var user = await LazyUserAsync(userClaims);
        var dbFolder = await Task.Run(() => user!.ReadEstimations());
        var folder = CreateFolder(dbFolder);
        return folder;
    }

    private Folder CreateFolder(DatabaseFolder root)
    {
        var folder = new Folder
        {
            FolderNum = root.FolderNum,
            ParentNum = root.Parent is null ? -2 : root.Parent.FolderNum,
            Name = root.Name ?? string.Empty,
            DbEstimations = new List<EstimationInfo>(),
            SubFolders = new List<Folder>()
        };
        foreach (var estimation in root.Estimations)
        {
            folder.DbEstimations.Add(CreateEstimationInfo(estimation, folder.FolderNum));
        }
        foreach (var subFolder in root.Folders)
        {
            folder.SubFolders.Add(CreateFolder(subFolder));
        }
        return folder;
    }
    private EstimationInfo CreateEstimationInfo(DatabaseEstimation dbEstimation, int folderNum)
    {
        return new EstimationInfo
        {
            FolderNum = folderNum,
            Name = dbEstimation.Name,
            Description = dbEstimation.Description,
            Id = dbEstimation.ID,
        };
    }
    
}
