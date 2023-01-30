namespace ApiClient.Bidcon.Services;
public class BidConConfigProvider : IBidConConfigProvider
{
    private readonly IConfiguration _configuration;

    public BidConConfigProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GetBidConConfigFilePath()
    {
        return _configuration.GetValue<string>(Constants.BidConConfigFilePath);
    }

    public string GetPassword()
    {
        return _configuration.GetValue<string>(Constants.BidConUserName);
    }

    public string GetUserName()
    {
        return _configuration.GetValue<string>(Constants.BidConUserPassword);
    }
}
