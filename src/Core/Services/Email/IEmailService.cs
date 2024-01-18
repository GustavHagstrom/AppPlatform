namespace AppPlatform.Core.Services.Email;

public interface IEmailService
{
    Task SendAsync(string to, string subject, string body, bool isBodyHtml = false);
}
