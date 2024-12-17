using AppPlatform.Core.Models.Authorization;
using AppPlatform.Core.Models.EstimationView;
using MongoEnteties = AppPlatform.Data.MongoDb.Enteties;
using AppPlatform.ViewSettingsModule.Data.Abstractions;
using MongoDB.Driver;

namespace AppPlatform.ViewSettingsModule.Data.Mongo;
internal class MongoRoleViewStore
    (
    IMongoCollection<MongoEnteties.EstimationView.RoleView> roleViewCollection, 
    IMongoCollection<MongoEnteties.Authorization.Role> roleCollection) 
    : IRoleViewStore
{
    public async Task<IEnumerable<string>> GetPickedRoleIdsAsync(View view)
    {
        var roleViews = await roleViewCollection.Find(r => r.ViewId == view.Id).ToListAsync();
        return roleViews.Select(x => x.RoleId);
    }

    public async Task<IEnumerable<Role>> GetRolesAsync(string tenantId)
    {
        var roles = await roleCollection.Find(r => r.TenantId == tenantId).ToListAsync();
        return roles.Select(r => new Role
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description
        });
    }

    public Task PickAsync(View view, IEnumerable<string> roleIds)
    {
        var roleViews = roleIds.Select(x => new MongoEnteties.EstimationView.RoleView
        {
            RoleId = x,
            ViewId = view.Id
        });
        return roleViewCollection.InsertManyAsync(roleViews);
    }

    public Task UnpickAsync(View view, IEnumerable<string> roleIds)
    {
        return roleViewCollection.DeleteManyAsync(r => r.ViewId == view.Id && roleIds.Contains(r.RoleId));
    }
}
