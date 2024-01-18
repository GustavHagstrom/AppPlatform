//using AppPlatform.BidconDataAccess;
//using AppPlatform.Core.Services.Settings;

//namespace AppPlatform.Core.Services;

//public class BidconConnectionstringService : IConnectionstringService
//{
//    private readonly IBidconCredentialsService _bidconCredentialsService;

//    public BidconConnectionstringService(IBidconCredentialsService bidconCredentialsService)
//    {
//        _bidconCredentialsService = bidconCredentialsService;
//    }
//    public async Task<string> BuildAsync(string? organization)
//    {
//        throw new NotImplementedException();
//        ArgumentException.ThrowIfNullOrEmpty(organization);

//        //var credentials = await _bidconCredentialsService.GetAsync();

//        //ArgumentNullException.ThrowIfNull(credentials);
//        //ArgumentException.ThrowIfNullOrEmpty(credentials.Server);
//        //ArgumentException.ThrowIfNullOrEmpty(credentials.Database);
//        //if (credentials.ServerAuthentication)
//        //{
//        //    ArgumentException.ThrowIfNullOrEmpty(credentials.User);
//        //    ArgumentException.ThrowIfNullOrEmpty(credentials.Password);
//        //}
//        //return credentials.ServerAuthentication
//        //    ? $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;uid={credentials.User};pwd={credentials.Password};TrustServerCertificate=True"
//        //    : $"Data Source={credentials.Server};Initial Catalog={credentials.Database}; Connect Timeout = 60;Integrated security=true;TrustServerCertificate=True;Encrypt=False;Multi Subnet Failover=False";
//    }


//}
