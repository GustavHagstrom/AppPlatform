using SharedPlatformLibrary.Enteties;

namespace License.Api.Features.AppSeed;
public interface IAppSeedService
{
    Task SeedAplicationDataAsync(AppSeedModel seedModel);
}
