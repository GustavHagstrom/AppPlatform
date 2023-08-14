using SharedPlatformLibrary.DTOs;

namespace License.Api.Features.AppSeed;
public interface IAppSeedService
{
    Task SeedAplicationDataAsync(AppSeedDTO seedModel);
}
