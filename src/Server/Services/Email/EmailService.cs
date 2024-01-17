using AppPlatform.Server.Enteties;
using System.Net.Mail;
using System.Net;

namespace AppPlatform.Server.Services.Email;
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

    public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
    {
        var subject = "Confirm your email";
        var body = $"Please confirm your account by clicking this link: <a href='{confirmationLink}'>link</a>";
        var isBodyHtml = true;
        return SendAsync(email, subject, body, isBodyHtml);
    }

    public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
    {
        var subject = "Reset your password";
        var body = $"Your reset code is: {resetCode}";
        var isBodyHtml = false;
        return SendAsync(email, subject, body, isBodyHtml);
    }

    public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
    {
        var subject = "Reset your password";
        var body = $"Please reset your password by clicking this link: <a href='{resetLink}'>link</a>";
        var isBodyHtml = true;
        return SendAsync(email, subject, body, isBodyHtml);
    }
}
