using SharedLibrary.Models;

namespace PublicWorkerWasmClient.Authentication.Services;
public interface ILoginService
{
    Task<bool> LoginAsync(LoginModel loginModel);
    Task<bool> LogoutAsync();
}