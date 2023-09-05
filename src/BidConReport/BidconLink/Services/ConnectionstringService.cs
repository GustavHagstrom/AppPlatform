using BidConReport.Shared.DTOs.BidconAccess;
using System.Security.Cryptography;

namespace BidconLink.Services;
public class ConnectionstringService : IConnectionstringService
{
    private readonly byte[] ENCRYPTION_KEY = new byte[8] { 45, 103, 246, 79, 36, 99, 167, 3 };
    private readonly byte[] VECTOR = new byte[8] { 55, 103, 246, 79, 36, 99, 167, 3 };
    public string Build(BC_DatabaseCredentialsDto credentials)
    {
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
            using StreamReader streamReader = new StreamReader(new CryptoStream(new MemoryStream(array), desCryptoServiceProvider.CreateDecryptor(ENCRYPTION_KEY, VECTOR), CryptoStreamMode.Read));
            return streamReader.ReadToEnd();
        }
        return string.Empty;
    }
}
