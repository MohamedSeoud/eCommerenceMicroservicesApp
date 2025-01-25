using eCommerence.Core.DTO;
using eCommerence.Core.IServicesContract;
using Microsoft.AspNetCore.Mvc;

namespace eCommerence.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserServices _userServices;
    public AuthController(IUserServices userServices) 
    {
    _userServices = userServices;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null) 
        {
            return BadRequest("Invalid Registeration");
        }
        AuthenticationResponse? authenticationResponse = await _userServices.Register(registerRequest);
        if (authenticationResponse == null || authenticationResponse.Sucess == false) 
        {
            return BadRequest(authenticationResponse);
        }
        return Ok(authenticationResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null) return BadRequest("Invalid Data");
        AuthenticationResponse? authenticationResponse = await _userServices.Login(loginRequest);
        if(authenticationResponse == null || authenticationResponse.Sucess == false)  return Unauthorized(authenticationResponse);
        return Ok(authenticationResponse);
    }
}
