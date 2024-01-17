namespace AppPlatform.Server.Services.Email;

public class EmailCredentials
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string NoReplyEmail { get; set; } = string.Empty;
}
