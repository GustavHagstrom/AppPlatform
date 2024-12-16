
using AppPlatform.Core.Abstractions;

namespace AppPlatform.SharedModule.Services;

public interface IAccessClaimInfoContainer
{
    IReadOnlyCollection<IAccessClaimInfo> AccessClaimInfos { get; }
}