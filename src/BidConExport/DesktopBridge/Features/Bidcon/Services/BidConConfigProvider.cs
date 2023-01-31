namespace DesktopBridge.Features.Bidcon.Services;
public class BidConConfigProvider : IBidConConfigProvider
{
    private readonly IConfiguration _configuration;

    public BidConConfigProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GetPassword()
    {
        return _configuration.GetValue<string>(BidconConfigConstants.BidConUserName)!;
    }

    public string GetUserName()
    {
        return _configuration.GetValue<string>(BidconConfigConstants.BidConUserPassword)!;
    }
}
