namespace ApiClient.Bidcon.Services;
public interface IBidConConfigProvider
{
    string GetBidConConfigFilePath();
    string GetUserName();
    string GetPassword();
}
