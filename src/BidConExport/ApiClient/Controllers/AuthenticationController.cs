using ApiClient.Authentication;
using DataAccessLibrary.Stores;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Exceptions;
using SharedLibrary.Models;

namespace ApiClient.Controllers;
[Route("[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserStore _userStore;
    private readonly ILogger _logger;

    public AuthenticationController(IAuthenticationService authenticationService, IUserStore userStore, ILogger<AuthenticationController> logger)
    {
        _authenticationService = authenticationService;
        _userStore = userStore;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserModel registerUserModel)
    {
        await _userStore.CreateAsync(registerUserModel);
        return Ok();
    }
    [HttpPost("login")]
    public async Task<IActionResult> GetLoginToken(LoginModel loginModel)
    {
        try
        {
            return Ok(await _authenticationService.GetAuthenticationTokenAsync(loginModel));
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
    [HttpPost("activate-refreshtoken")]
    public async Task<IActionResult> ActivateAccessTokenByRefresh(TokenModel refreshToken)
    {
        try
        {
            return Ok(await _authenticationService.ActivateTokenUsingRefreshToken(refreshToken));
        }
        catch (InvalidRefreshTokenException e)
        {
            return ValidationProblem(e.Message);
        }
        catch (Exception)
        {
            return ValidationProblem();
        }
    }
}
