using AppPlatform.Server.Services.Email;

namespace Tests.Server.Services.Email;
[TestFixture]
public class EmailServiceTests
{
    public EmailCredentials Credentials { get; set; } = new EmailCredentials
    {
        Host = "localhost", //MailHog
        Port = 1025, //MailHog
        Username = "username",
        Password = "password",
    };
    [Test]
    public void SendAsync_ShouldNotThrow()
    {
        //var service = new EmailService(Credentials);
        //Assert.DoesNotThrowAsync(async () => await service.SendAsync("from@me.com", "to@you.com", "subject", "body", false));
    }
}
