using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SharedLibrary.Models;
using System.Security.Cryptography;

namespace DataAccessLibrary.Helpers;
public static class PasswordHasher
{
    public static void AddHashAndSaltToUser(User user, string password)
    {
        var salt = RandomNumberGenerator.GetBytes(128 / 8);
        user.Salt = Convert.ToBase64String(salt);
        user.PasswordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8));
    }
    public static bool Match(User user, string password)
    {
        var salt = Convert.FromBase64String(user.Salt);
        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8));
        return user.PasswordHash.Equals(hash);
    }
}
