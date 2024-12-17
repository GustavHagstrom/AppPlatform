using AppPlatform.Core.Models.EstimationView;
using AppPlatform.ViewSettingsModule.Data.Abstractions;
using MongoDB.Driver;
using MongoEnteties = AppPlatform.Data.MongoDb.Enteties;

namespace AppPlatform.ViewSettingsModule.Data.Mongo;
internal class MongoUserViewStore(IMongoCollection<MongoEnteties.EstimationView.UserView> userViewStore) : IUserViewStore
{
    public async Task<IEnumerable<string>> GetPickedUserIdsAsync(View view)
    {
        var userViews = await userViewStore.Find(x => x.ViewId == view.Id).ToListAsync();
        return userViews.Select(x => x.UserId);
    }

    public Task PickAsync(View view, IEnumerable<string> userIds)
    {
        var userViews = userIds.Select(x => new MongoEnteties.EstimationView.UserView
        {
            UserId = x,
            ViewId = view.Id
        });
        return userViewStore.InsertManyAsync(userViews);
    }

    public Task UnpickAsync(View view, IEnumerable<string> userIds)
    {
        return userViewStore.DeleteManyAsync(x => x.ViewId == view.Id && userIds.Contains(x.UserId));
    }
}
