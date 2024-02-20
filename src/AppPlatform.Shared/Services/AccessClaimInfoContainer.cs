using AppPlatform.Shared.Abstractions;

namespace AppPlatform.Shared.Services;
public class AccessClaimInfoContainer : IAccessClaimInfoContainer
{
    public AccessClaimInfoContainer(IEnumerable<IAccessClaimInfo> accessClaimInfos)
    {
        AccessClaimInfos = accessClaimInfos.ToHashSet();
    }
    public IReadOnlyCollection<IAccessClaimInfo> AccessClaimInfos { get; }

}
