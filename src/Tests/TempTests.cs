using AppPlatform.Core.Services;

namespace AppPlatform.Tests;
[TestFixture]
public class TempTests
{
    [Test]
    public async Task Test()
    {
        var service = new MicrosoftGraphService("cc20f9d0-7c68-43c3-ad3e-198102c2f4bf", "S1O8Q~~x3QQf8ZG~XAB5b1Qn.090j3bfC4Knbbvd");
        await service.GivePermissionAsync();

        Assert.Pass();
    }
}
