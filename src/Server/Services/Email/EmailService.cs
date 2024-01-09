using Server.Enteties;
using System.Net.Mail;
using System.Net;

namespace Server.Services.Email;
//Needs integration tests
public class EmailService(EmailCredentials credentails) : IEmailService
{
    public async Task SendAsync(string from, string to, string subject, string body, bool isBodyHtml = false)
    {
        using (var mail = new MailMessage())
        {
            mail.From = new MailAddress(from);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            using (SmtpClient smtp = new SmtpClient(credentails.Host, credentails.Port))
            {
                smtp.Credentials = new NetworkCredential(credentails.Username, credentails.Password);
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
