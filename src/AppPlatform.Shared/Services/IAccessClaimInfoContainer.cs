
using AppPlatform.Core.Abstractions;

namespace AppPlatform.Shared.Services;

public interface IAccessClaimInfoContainer
{
    IReadOnlyCollection<IAccessClaimInfo> AccessClaimInfos { get; }
}