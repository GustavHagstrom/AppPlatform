using System.Security.Cryptography;

namespace BidConReport.BidconAccess.Services;
public class ConnectionstringService : IConnectionstringService
{
    private readonly byte[] ENCRYPTION_KEY = new byte[8] { 45, 103, 246, 79, 36, 99, 167, 3 };
    private readonly IDatabaseCredentialsService _databaseCredentialsService;

    public ConnectionstringService(IDatabaseCredentialsService databaseCredentialsService)
    {
        _databaseCredentialsService = databaseCredentialsService;
    }
    public async Task<string> BuildAsync()
    {
        var credentials = await _databaseCredentialsService.GetAsync();
        if (credentials.ServerAuthentication)
        {
            var password = Decrypt(credentials.PwHash);
            return $"Data Source={credentials.Server};Initial Catalog={credentials.Databse}; Connect Timeout = 60;uid={credentials.User};pwd={password};TrustServerCertificate=True";
        }
        else
        {
            return $"Data Source={credentials.Server};Initial Catalog={credentials.Databse}; Connect Timeout = 60;Integrated security=true;TrustServerCertificate=True;Encrypt=False;Multi Subnet Failover=False";
        }
    }

    private string Decrypt(string encryptedPassword)
    {
        byte[] encryptionKey = ENCRYPTION_KEY;
        byte[] rgbIV = new byte[8] { 55, 103, 246, 79, 36, 99, 167, 3 };
        if (!string.IsNullOrEmpty(encryptedPassword))
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            using DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[]? array = null;
            try
            {
                array = Convert.FromBase64String(encryptedPassword);
            }
            catch
            {
                return string.Empty;
            }
            using StreamReader streamReader = new StreamReader(new CryptoStream(new MemoryStream(array), desCryptoServiceProvider.CreateDecryptor(encryptionKey, rgbIV), CryptoStreamMode.Read));
            return streamReader.ReadToEnd();
        }
        return string.Empty;
    }
}
