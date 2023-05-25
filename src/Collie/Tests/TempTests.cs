using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Collie.Tests;
public class TempTests
{
    //[Test]
    [TestCase("VX3EEWKNQrrBQp+52Ct5Gw==")]
    [TestCase("1xIFE/OYDJuUDSGwDNJUTw==")]
    public void TempTest1(string encryptedPassword)
    {
        byte[] eNCRYPTION_KEY = new byte[8] { 45, 103, 246, 79, 36, 99, 167, 3 };
        byte[] rgbIV = new byte[8] { 55, 103, 246, 79, 36, 99, 167, 3 };
        DESCryptoServiceProvider dESCryptoServiceProvider = new();
        byte[] array = Convert.FromBase64String(encryptedPassword);
        var decryptedPass = new StreamReader(new CryptoStream(new MemoryStream(array), dESCryptoServiceProvider.CreateDecryptor(eNCRYPTION_KEY, rgbIV), CryptoStreamMode.Read)).ReadToEnd();
        Assert.That(decryptedPass, Is.EqualTo("lol"));
    }
}
