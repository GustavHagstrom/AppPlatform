namespace AppPlatform.Shared.Authorization;
public class AccessIdContainer
{
    public AccessIdContainer(IReadOnlyCollection<string> accessIds)
    {
        AccessIds = accessIds;
    }
    public IReadOnlyCollection<string> AccessIds { get; private set; }

}
