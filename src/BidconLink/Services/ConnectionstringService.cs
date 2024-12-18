﻿using AppPlatform.BidconDatabaseAccess.DbAccess.Services;
using AppPlatform.BidconLink.Constants;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AppPlatform.BidconLink.Services;
public class ConnectionstringService : IBidconDbConnectionstringService
{
    private readonly byte[] ENCRYPTION_KEY = new byte[8] { 45, 103, 246, 79, 36, 99, 167, 3 };
    private readonly byte[] VECTOR = new byte[8] { 55, 103, 246, 79, 36, 99, 167, 3 };
    private readonly IBidconConfigService _bidconConfigService;

    public ConnectionstringService(IBidconConfigService bidconConfigService)
    {
        _bidconConfigService = bidconConfigService;
    }
    public async Task<string> BuildAsync(ClaimsPrincipal userClaims)
    {
        var map = _bidconConfigService.ConfigMap();

        var requiredAuthentication = map[ConfigConstants.SqlServerAuthenticationMode] == "1";
        var server = GetServer(map);
        var database = GetDatabase(map);
        var user = GetUser(map);
        var password = GetPassword(map);

        return await Task.FromResult(requiredAuthentication
            ? $"Data Source={server};Initial Catalog={database}; Connect Timeout = 60;uid={user};pwd={password};TrustServerCertificate=True"
            : $"Data Source={server};Initial Catalog={database}; Connect Timeout = 60;Integrated security=true;TrustServerCertificate=True;Encrypt=False;Multi Subnet Failover=False");
    }

    private string GetPassword(Dictionary<string, string> map)
    {
        return map[ConfigConstants.DBMode] == "1"
            ? Decrypt(map[ConfigConstants.CentralEstimationDatabasePassword])
            : Decrypt(map[ConfigConstants.LocalEstimationDatabasePassword]);
    }

    private string GetUser(Dictionary<string, string> map)
    {
        return map[ConfigConstants.DBMode] == "1"
            ? map[ConfigConstants.CentralEstimationDatabaseUserId]
            : map[ConfigConstants.LocalEstimationDatabaseUserId];
    }

    private string GetDatabase(Dictionary<string, string> map)
    {
        return map[ConfigConstants.DBMode] == "1"
            ? map[ConfigConstants.CentralEstimationDatabaseName]
            : map[ConfigConstants.LocalEstimationDatabaseName];
    }

    private string GetServer(Dictionary<string, string> map)
    {
        return map[ConfigConstants.DBMode] == "1"
            ? map[ConfigConstants.CentralEstimationServerName]
            : map[ConfigConstants.LocalEstimationServerName];
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
