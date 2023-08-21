using System.Security.Cryptography;

namespace BidConReport.DirectAccess.Services;
internal class ConnectionStringBuilder : IConnectionStringBuilder
{
    private readonly byte[] ENCRYPTION_KEY = new byte[8] { 45, 103, 246, 79, 36, 99, 167, 3 };
    private readonly IDatabaseCredentialsService _databaseCredentialsService;

    public ConnectionStringBuilder(IDatabaseCredentialsService databaseCredentialsService)
    {
        _databaseCredentialsService = databaseCredentialsService;
    }
    public async Task<string> BuildAsync()
    {
        var credentials = await _databaseCredentialsService.GetAsync();
        var password = Decrypt(credentials.PwHash);
        var security = credentials.ServerAuthentication ? $"uid={credentials.User};pwd={password}" : "Integrated security=true";
        return $"Data Source={credentials.Server};Initial Catalog={credentials.Databse}; Connect Timeout = 60;{security}";
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
