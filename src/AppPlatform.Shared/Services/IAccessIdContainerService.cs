
namespace AppPlatform.Shared.Services;

public interface IAccessIdContainerService
{
    IReadOnlyCollection<string> AccessIds { get; }
}