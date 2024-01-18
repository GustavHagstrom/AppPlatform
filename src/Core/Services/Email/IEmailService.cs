using Microsoft.AspNetCore.Identity;
using AppPlatform.Core.Enteties;

namespace AppPlatform.Core.Services.Email;

public interface IEmailService : IEmailSender<User>
{
    Task SendAsync(string to, string subject, string body, bool isBodyHtml = false);
}
