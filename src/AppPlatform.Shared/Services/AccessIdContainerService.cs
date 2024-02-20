namespace AppPlatform.Shared.Services;
public class AccessIdContainerService : IAccessIdContainerService
{
    public AccessIdContainerService(IReadOnlyCollection<string> accessIds)
    {
        AccessIds = accessIds;
    }
    public IReadOnlyCollection<string> AccessIds { get; private set; }

}
