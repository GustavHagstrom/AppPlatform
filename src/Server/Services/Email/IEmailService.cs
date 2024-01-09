using Microsoft.AspNetCore.Identity;
using Server.Enteties;

namespace Server.Services.Email;

public interface IEmailService : IEmailSender<User>
{
    Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = false);
}
