namespace AppPlatform.Shared.Services;
public class AccessIdContainerService
{
    public AccessIdContainerService(IReadOnlyCollection<string> accessIds)
    {
        AccessIds = accessIds;
    }
    public IReadOnlyCollection<string> AccessIds { get; private set; }

}
