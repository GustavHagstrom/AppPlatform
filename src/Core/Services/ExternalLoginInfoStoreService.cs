using Microsoft.AspNetCore.Identity;

namespace AppPlatform.Core.Services;
public class ExternalLoginInfoStoreService : IExternalLoginInfoStoreService
{
    public ExternalLoginInfo? ExternalLoginInfo { get; set; }
}
