using BidConReport.Shared.Enums;
using SharedPlatformLibrary.Constants;
using SharedPlatformLibrary.DTOs;

namespace BidConReport.Server.Services.Authentication;

public class ClaimsService_debug : IClaimsService
{
    public string License { get; set; } = "debug_license";


    public async Task<ICollection<ClaimDTO>> GetClaimsAsync(string userId)
    {
        var rightValuesString = string.Join(",", Enum.GetValues<ApplicationRight>()
            .Select(x => ((int)x).ToString()));

        var claims = new List<ClaimDTO>
        {
            new ClaimDTO(CustomClaimTypes.License, License),
            new ClaimDTO(CustomClaimTypes.ApplicationRight, rightValuesString),
        };

        return await Task.FromResult(claims);
    }
}
