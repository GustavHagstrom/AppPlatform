using Server.Enteties;
using System.Net.Mail;
using System.Net;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Server.Services.Email;
//Needs integration tests
public class EmailService : IEmailService
{
    private readonly EmailCredentials _credentials;
    public EmailService(IConfiguration configuration)
    {
        _credentials = configuration.GetSection("EmailCredentials").Get<EmailCredentials>() ?? throw new InvalidOperationException("Section 'EmailCredentials' not found.");
    }
    public async Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = false)
    {
        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            using (SmtpClient smtp = new SmtpClient(_credentials.Host, _credentials.Port))
            {
                smtp.Credentials = new NetworkCredential(_credentials.Username, _credentials.Password);
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(mail);
            }
        }
    }

    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        throw new NotImplementedException();
    }
}
