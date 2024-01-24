using Microsoft.AspNetCore.Identity;

namespace AppPlatform.Core.Services;
public interface IExternalLoginInfoStoreService
{
    ExternalLoginInfo? ExternalLoginInfo { get; set; }
}