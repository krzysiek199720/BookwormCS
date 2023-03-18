using Bookworm.Controllers.Services.Interfaces;
using Bookworm.Data;
using Bookworm.DTO;
using Bookworm.DTO.Results;
using Bookworm.Entities.Auth;
using Bookworm.Extensions.ResultConverters;
using Bookworm.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookworm.Controllers;

public class AuthController : ApiBaseController
{
    public IAuthService AuthService { get; }

    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginDto>> Login(LoginRequest loginRequest)
    {
        var user = AuthService.GetUserByEmail(loginRequest.Email);
        if (user == null)
            return Unauthorized("Invalid login info");
        var result = await AuthService.CheckPassword(user, loginRequest.Password);
        if(!result) 
            return Unauthorized("Invalid login info");

        var token = await AuthService.CreateToken(user);
        
        return user.ToLoginDto(token);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<LoginDto>> Register(RegisterRequest registerRequest)
    {
        var checkUser = AuthService.GetUserByEmail(registerRequest.Email);
        if (checkUser != null)
            return BadRequest("Email taken");

        var user = new AppUser { Email = registerRequest.Email, UserName = registerRequest.Username};
        var result = await AuthService.CreateUser(user, registerRequest.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);
        var roleResult = await AuthService.AddRole(user, "User");
        if (!roleResult.Succeeded)
            return BadRequest(roleResult.Errors);
        
        var token = await AuthService.CreateToken(user);
        
        return user.ToLoginDto(token);
    }
}