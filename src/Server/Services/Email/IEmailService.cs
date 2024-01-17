using Microsoft.AspNetCore.Identity;
using AppPlatform.Server.Enteties;

namespace AppPlatform.Server.Services.Email;

public interface IEmailService : IEmailSender<User>
{
    Task SendAsync(string to, string subject, string body, bool isBodyHtml = false);
}
