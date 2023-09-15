using SharedLibrary.DTOs.BidconAccess;
using Microsoft.AspNetCore.Components.Forms;

namespace Client.Features.Settings.BidconSettings.BicdonCredentials;
public interface IConfigReaderService
{
    Task<BC_DatabaseCredentialsDto?> ReadCredentialsAsync(IBrowserFile browserFile);
}