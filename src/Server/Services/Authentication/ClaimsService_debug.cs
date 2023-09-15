using SharedLibrary.Constants;
using SharedLibrary.DTOs;
using SharedLibrary.Enums;

namespace Server.Services.Authentication;

public class ClaimsService_debug : IClaimsService
{
    public string License { get; set; } = "debug_license";


    public async Task<ICollection<ClaimDto>> GetClaimsAsync(string userId)
    {
        var rightValuesString = string.Join(",", Enum.GetValues<ApplicationRight>()
            .Select(x => ((int)x).ToString()));

        var claims = new List<ClaimDto>
        {
            new ClaimDto(ApplicationClaimConstants.License, License),
            new ClaimDto(ApplicationClaimConstants.ApplicationRight, rightValuesString),
        };

        return await Task.FromResult(claims);
    }
}
