using BidconLink.Services;

namespace Tests.BidconLink.Services;

public class BidconConfigServiceTests
{
    public void Setup()
    {

    }

    public void IniPath_Should()
    {
        var service = new BidconConfigService();

        var ini = service.IniPath();
        var config = service.ConfigPath();
        var settings = service.ConfigMap();

    }
}
