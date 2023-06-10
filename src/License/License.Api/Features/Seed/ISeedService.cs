using SharedPlatformLibrary.Enteties;

namespace License.Api.Features.Seed;
public interface ISeedService
{
    Task SeedAplicationDataAsync(AppSeedModel seedModel);
}
