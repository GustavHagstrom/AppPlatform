using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace AppPlatform.Shared.Services.Email;
//Needs integration tests
public class EmailService : IEmailService
{
    private readonly EmailCredentials _credentials;

    public EmailService(IConfiguration configuration)
    {
        _credentials = configuration.GetSection("EmailCredentials").Get<EmailCredentials>() ?? throw new InvalidOperationException("Section 'EmailCredentials' not found.");
    }
    public async Task SendAsync(string to, string subject, string body, bool isBodyHtml = false)
    {
        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress(_credentials.NoReplyEmail);
            mail.Sender = new MailAddress(_credentials.NoReplyEmail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            using (SmtpClient smtp = new SmtpClient(_credentials.Host, _credentials.Port))
            {
                smtp.Credentials = new NetworkCredential(_credentials.Username, _credentials.Password);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
