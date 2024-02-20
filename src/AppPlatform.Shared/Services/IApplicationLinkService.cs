using AppPlatform.Shared.Abstractions;

namespace AppPlatform.Shared.Services;
public interface IApplicationLinkService
{
    IEnumerable<IApplicationLink> MainLayoutLinks { get; }
}