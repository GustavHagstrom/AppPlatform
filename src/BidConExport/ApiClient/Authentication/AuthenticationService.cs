using DataAccessLibrary.Helpers;
using DataAccessLibrary.Stores;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Authentication;
using SharedLibrary.Exceptions;
using SharedLibrary.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiClient.Authentication;
public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly IUserStore _userStore;
    private readonly IUserRoleStore _userRoleStore;

    public AuthenticationService(IConfiguration configuration, IUserStore userStore, IUserRoleStore userRoleStore)
    {
        _configuration = configuration;
        _userStore = userStore;
        _userRoleStore = userRoleStore;
    }

    public async Task<TokenModel> GetAuthenticationTokenAsync(LoginModel loginModel)
    {
        User user = await _userStore.FindByEmailAsync(loginModel.Email);
        if (PasswordHasher.Match(user, loginModel.Password))
        {
            var userCliams = CreateUserClaimsAsync(user, await _userRoleStore.GetUserRolesForUser(user));
            var tokenModel = CreateToken(userCliams);
            await UpdateUserRefreshTokenAsync(user, tokenModel);
            return tokenModel;
        }
        else
        {
            throw new EmailOrPasswordException();
        }
    }
    public async Task<TokenModel> ActivateTokenUsingRefreshToken(TokenModel tokenModel)
    {
        var claimsPrincipal = GetClaimsPrincipal(tokenModel.Token);
        var email = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Email).Select(x => x.Value).First();
        try
        {
            var user = await _userStore.FindByEmailAsync(email);
            if (user.RefreshToken != tokenModel.RefreshToken)
            {
                throw new InvalidRefreshTokenException();
            }
            var userCliams = CreateUserClaimsAsync(user, await _userRoleStore.GetUserRolesForUser(user));
            var newTokenModel = CreateToken(userCliams);
            await UpdateUserRefreshTokenAsync(user, newTokenModel);
            return newTokenModel;
        }
        catch (InvalidRefreshTokenException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new EmailOrPasswordException();
        }

    }
    private ClaimsPrincipal GetClaimsPrincipal(string token)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _configuration.GetValue<string>(Constants.TokenIssuerEnvVariable),
            ValidateAudience = true,
            ValidAudience = _configuration.GetValue<string>(Constants.TokenAudienceEnvVariable),
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>(Constants.TokenKeyEnvVariable))),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                throw new Exception("Access token is invalid");
            }
            return claimsPrincipal;
        }
        catch (Exception)
        {
            throw new Exception("Access token is invalid");
        }
    }
    private static IEnumerable<Claim> CreateUserClaimsAsync(User user, IEnumerable<UserRole> roles)
    {
        yield return new Claim(ClaimTypes.Email, user.Email);
        yield return new Claim(CustomClaimTypes.FirstName, user.FirstName);
        yield return new Claim(CustomClaimTypes.LastName, user.LastName);
        foreach (var role in roles)
        {
            yield return new Claim(ClaimTypes.Role, role.Name);
        }
    }
    private TokenModel CreateToken(IEnumerable<Claim> claims)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>(Constants.TokenKeyEnvVariable)));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>(Constants.TokenIssuerEnvVariable),
                audience: _configuration.GetValue<string>(Constants.TokenAudienceEnvVariable),
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials,
                claims: claims
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        string refreshToken = CreateRefreshToken();

        return new TokenModel { Token = token, RefreshToken = refreshToken };
    }
    private static string CreateRefreshToken()
    {
        var key = new byte[32];
        using (var refreshTOkenGenerator = RandomNumberGenerator.Create())
        {
            refreshTOkenGenerator.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
    private async Task UpdateUserRefreshTokenAsync(User user, TokenModel newTokenModel)
    {
        user.RefreshToken = newTokenModel.RefreshToken;
        await _userStore.UpdateAsync(user);
    }
}
