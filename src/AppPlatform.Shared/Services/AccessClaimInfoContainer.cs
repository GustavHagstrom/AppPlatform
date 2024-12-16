using AppPlatform.Core.Abstractions;

namespace AppPlatform.SharedModule.Services;
public class AccessClaimInfoContainer : IAccessClaimInfoContainer
{
    public AccessClaimInfoContainer(IEnumerable<IAccessClaimInfo> accessClaimInfos)
    {
        AccessClaimInfos = accessClaimInfos.ToHashSet();
    }
    public IReadOnlyCollection<IAccessClaimInfo> AccessClaimInfos { get; }

}
