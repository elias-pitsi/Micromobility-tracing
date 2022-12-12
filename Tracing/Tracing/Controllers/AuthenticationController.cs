using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tracing.DataAccess.Dtos;
using Tracing.DataAccess.Models;
using Tracing.Services.interfaces;

namespace Tracing.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthentication _authentication;
    private readonly IEmailService _emailService;

    public AuthenticationController(IAuthentication authentication, IEmailService emailService)
    {
        _authentication = authentication;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationRequest>> Register(OwnerRegistrationDto request)
    {
        var result = await _authentication.Registration(request);
        var response = new RegistrationRequest
        {
            res = result,
            Success = true
        }; 
        return Ok(response);
    }

    [HttpPost("login")]
    // [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(OwnerLoginDto request)
    {
        var response = await _authentication.Login(request);
        var getLogin = new LoginResponse
        {
            Token = response.Token, 
            OwnerId = response.OwnerId,
            Email = response.Email,
            returnMessage = "Suceess"
        };

        return Ok(getLogin);
    }

    [HttpPost("verify")]
    public async Task<ActionResult<OwnerRegistrationDto>> Verify(string token)
    {
        return Ok(await _authentication.Verify(token)); 
    }

    [HttpPost("forgotpassword")]
    public async Task<ActionResult<OwnerRegistrationDto>> ForgotPassword(string email)
    {
        var pass = await _authentication.ForgotPassword(email);
        return Ok(pass);
    }

    [HttpPost("resetpassword")]
    public async Task<ActionResult<ResetPasswordRequest>> ResetPassword(ResetPasswordRequest request)
    {
        var user = await _authentication.ResetPassword(request);
        return Ok(user);
    }
    
    
    [HttpPost]
    public IActionResult SendEmail(EmailDto request)
    {
         _emailService.SendEmail(request);
        return Ok();
    }

}
